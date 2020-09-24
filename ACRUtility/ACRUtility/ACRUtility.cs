using MiFare;
using MiFare.Classic;
using MiFare.Devices;
using MiFare.PcSc.Iso7816;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ACRUtility
{
    public partial class ACRUtility : Form
    {
        private List<string> outputString = new List<string>();

        private SmartCardReader reader;
        private MiFareCard card;

        private IList<SectorKeySet> authenticationKeys = new List<SectorKeySet>();
        private byte[] defaultKeys =
        {
            0x19, 0x94, 0x04, 0x28, 0x19, 0x70
            //0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF
        };
        

        public ACRUtility()
        {
            InitializeComponent();
            setKeys();
            GetDevices();
        }

        private void setKeys()
        {
            for(var i = 0; i<defaultKeys.Length; i += 6)
            {
                authenticationKeys.Add(new SectorKeySet());
                authenticationKeys.Last().Key = new byte[6];
                for (var j = 0; j < 6; j++)
                {
                    authenticationKeys.Last().Key[j] = defaultKeys[j + i];
                    authenticationKeys.Last().KeyType = MiFare.Classic.KeyType.KeyA;
                }
            }
        }

        private async void GetDevices()
        {
            try
            {
                reader = await CardReader.FindAsync();
                if (reader == null)
                {
                    DisplayText("no reader detected");
                    return;
                }
                reader.CardAdded += CardAdded;
                reader.CardRemoved += CardRemoved;
            }
            catch (Exception e)
            {

            }
        }

        private async void CardAdded(object sender, CardEventArgs args)
        {
            card = args.SmartCard.CreateMiFareCard(authenticationKeys);

            var cardIdentification = await card.GetCardInfo();

            DisplayText("Connected to card PC/SC device class: " + cardIdentification.PcscDeviceClass.ToString() + "    Card name: " + cardIdentification.PcscCardName.ToString());

            var uid = await card.GetUid();
            DisplayText("UID:  " + BitConverter.ToString(uid));

            for (var sector = 0; sector < 16 && card != null; sector++)
            {
                try
                {
                    var data = await card.GetData(sector, 0, 48);

                    string hexString = "";
                    for (int i = 0; i < data.Length; i++)
                    {
                        hexString += data[i].ToString("X2") + " ";
                    }

                    DisplayText(string.Format("Sector '{0}':{1}", sector, hexString));

                }
                catch (Exception)
                {
                    DisplayText("Failed to load sector: " + sector);
                }
            }
        }

        private void CardRemoved(object sender, CardEventArgs args)
        {
            DisplayText("Card Removed");
        }

        private void DisplayText(string DisplayText)
        {
            output.Invoke(new Action(() => output.Items.Add(DisplayText)));
        }

        private bool checkMagic()
        {
            
            byte[] byteArray = { 0x43, 0x40 };

            PCSC.IContextFactory contextFactory = PCSC.ContextFactory.Instance;
            using (var ctx = contextFactory.Establish(PCSC.SCardScope.System))
            {
                var readerNames = ctx.GetReaders();
                using (var reader = ctx.ConnectReader(readerNames[0], PCSC.SCardShareMode.Shared, PCSC.SCardProtocol.Raw))
                {
                    var response = new byte[256];
                    reader.Transmit(byteArray, response);
                    DisplayText(String.Format("{0:X2}", response));
                }
            }
            return true;
        }

        private void beep()
        {
            byte[] byteArray = { 0x01, 0x01, 0x10, 0x03 };
            var cmd = new ApduCommand(0xFF, 0x00, 0x40, 0xF0, byteArray, 0x04);

            PCSC.IContextFactory contextFactory = PCSC.ContextFactory.Instance;
            using (var ctx = contextFactory.Establish(PCSC.SCardScope.System))
            {
                var readerNames = ctx.GetReaders();
                if(readerNames == null) { return; }
                using (var isoReader = new PCSC.Iso7816.IsoReader(ctx, readerNames[0], PCSC.SCardShareMode.Shared, PCSC.SCardProtocol.Any, false))
                {

                    var apdu = new PCSC.Iso7816.CommandApdu(PCSC.Iso7816.IsoCase.Case4Short, isoReader.ActiveProtocol)
                    {
                        CLA = 0xFF, // Class
                        Instruction = 0x00,
                        P1 = 0x40, // Parameter 1
                        P2 = 0xF0, // Parameter 2
                        Data = byteArray,
                        Le = 0x08 // Expected length of the returned data
                    };

                    var response = isoReader.Transmit(apdu);
                    DisplayText(String.Format("SW1 SW2 = {0:X2} {1:X2}", response.SW1, response.SW2));
                }
            }
        }

        private void cmdExecute_Click(object sender, EventArgs e)
        {
            DisplayText(txtCommand.Text);
            string[] cmd = txtCommand.Text.Split(' ');
            txtCommand.Clear(); 

            switch (cmd[0])
            {
                case("checkMagic"):
                    //if(card == null){
                    //    DisplayText("No Card Attached");
                    //    break;
                    //}
                    bool magic = checkMagic();
                    DisplayText(magic ? "The Card Is Magic" : "The card is Standard");
                    break;
                case ("beep"):
                    beep();
                    break;
                default:
                    break;
            }

        }
    }
}
