using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Save_Editor_1
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        public string savegame;

        public static byte[] ML4E_StringToByteArray(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private void ML4E_get_openfile()
        {
            OpenFileDialog openFD = new OpenFileDialog();
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                savegame = openFD.FileName;
            }
        }

        private void ML4E_get_data()
        {
            {
                FileStream savegame_fs = new FileStream(savegame, FileMode.Open);
                BinaryReader savegame_br = new BinaryReader(savegame_fs);
                long length = savegame_fs.Length;

                // Front Hammer Check
                savegame_br.BaseStream.Position = 0x0;
                byte rwfh = (byte)savegame_fs.ReadByte();
                int rwfh2 = (byte)((rwfh & 1));
                if (rwfh2 == 1)
                    checkBoxHammerFront.Checked = true;
                if (rwfh2 == 0)
                    checkBoxHammerFront.Checked = false;

                // Back Hammer Mini Mario Check
                savegame_br.BaseStream.Position = 0x0;
                byte rwbhmim = (byte)savegame_fs.ReadByte();
                int rwbhmim2 = (byte)((rwbhmim & 2) >> 1);
                if (rwbhmim2 == 1)
                    checkBoxHammerMiniMario.Checked = true;
                if (rwbhmim2 == 0)
                    checkBoxHammerMiniMario.Checked = false;

                // Back Hammer Mole Mario Check
                savegame_br.BaseStream.Position = 0x0;
                byte rwbhmom = (byte)savegame_fs.ReadByte();
                int rwbhmom2 = (byte)((rwbhmom & 4) >> 2);
                if (rwbhmom2 == 1)
                    checkBoxHammerMoleMario.Checked = true;
                if (rwbhmom2 == 0)
                    checkBoxHammerMoleMario.Checked = false;

                // Spin Jump Check
                savegame_br.BaseStream.Position = 0x0;
                byte rwsj = (byte)savegame_fs.ReadByte();
                int rwsj2 = (byte)((rwsj & 8) >> 3);
                if (rwsj2 == 1)
                    checkBoxSpinJump.Checked = true;
                if (rwbhmim2 == 0)
                    checkBoxSpinJump.Checked = false;

                // Side Drill Check
                savegame_br.BaseStream.Position = 0x0;
                byte rwsd = (byte)savegame_fs.ReadByte();
                int rwsd2 = (byte)((rwsd & 16) >> 4);
                if (rwsd2 == 1)
                    checkBoxSideDrill.Checked = true;
                if (rwsd2 == 0)
                    checkBoxSideDrill.Checked = false;

                // Ball Hop Check
                savegame_br.BaseStream.Position = 0x0;
                byte rwbh = (byte)savegame_fs.ReadByte();
                int rwbh2 = (byte)((rwbh & 32) >> 5);
                if (rwbh2 == 1)
                    checkBoxBallHop.Checked = true;
                if (rwbh2 == 0)
                    checkBoxBallHop.Checked = false;

                // DW B Button Check
                savegame_br.BaseStream.Position = 0x1;
                byte dwbb = (byte)savegame_fs.ReadByte();
                int dwbb2 = (byte)((dwbb & 4) >> 2);
                if (dwbb2 == 1)
                    checkBoxDWBButton.Checked = true;
                if (dwbb2 == 0)
                    checkBoxDWBButton.Checked = false;

                // Luiginary Stack Check
                savegame_br.BaseStream.Position = 0x1;
                byte dwls = (byte)savegame_fs.ReadByte();
                int dwls2 = (byte)((dwls & 8) >> 3);
                if (dwls2 == 1)
                    checkBoxDWStack.Checked = true;
                if (dwls2 == 0)
                    checkBoxDWStack.Checked = false;

                // Luiginary Stack: Ground Pound Check
                savegame_br.BaseStream.Position = 0x1;
                byte dwlsgp = (byte)savegame_fs.ReadByte();
                int dwlsgp2 = (byte)((dwlsgp & 64) >> 6);
                if (dwlsgp2 == 1)
                    checkBoxDWStackGP.Checked = true;
                if (dwlsgp2 == 0)
                    checkBoxDWStackGP.Checked = false;

                // Luiginary Stack: Spring Jump Check
                savegame_br.BaseStream.Position = 0x1;
                byte dwlssj = (byte)savegame_fs.ReadByte();
                int dwlssj2 = (byte)((dwlssj & 128) >> 7);
                if (dwlssj2 == 1)
                    checkBoxDWStackSJ.Checked = true;
                if (dwlssj2 == 0)
                    checkBoxDWStackSJ.Checked = false;

                // Luiginary Cone Check
                savegame_br.BaseStream.Position = 0x1;
                byte dwlc = (byte)savegame_fs.ReadByte();
                int dwlc2 = (byte)((dwlc & 16) >> 4);
                if (dwlc2 == 1)
                    checkBoxDWCone.Checked = true;
                if (dwlc2 == 0)
                    checkBoxDWCone.Checked = false;

                // Luiginary Cone: Jump Check
                savegame_br.BaseStream.Position = 0x2;
                byte dwlcj = (byte)savegame_fs.ReadByte();
                int dwlcj2 = (byte)((dwlcj & 1));
                if (dwlcj2 == 1)
                    checkBoxDWConeJ.Checked = true;
                if (dwlcj2 == 0)
                    checkBoxDWConeJ.Checked = false;

                // Luiginary Cone: Tornado Check
                savegame_br.BaseStream.Position = 0x2;
                byte dwlct = (byte)savegame_fs.ReadByte();
                int dwlct2 = (byte)((dwlct & 2) >> 1);
                if (dwlct2 == 1)
                    checkBoxDWConeT.Checked = true;
                if (dwlct2 == 0)
                    checkBoxDWConeT.Checked = false;

                // Luiginary Ball Check
                savegame_br.BaseStream.Position = 0x1;
                byte dwlb = (byte)savegame_fs.ReadByte();
                int dwlb2 = (byte)((dwlb & 32) >> 5);
                if (dwlb2 == 1)
                    checkBoxDWBall.Checked = true;
                if (dwlb2 == 0)
                    checkBoxDWBall.Checked = false;

                // Luiginary Ball: Slingshot Check
                savegame_br.BaseStream.Position = 0x2;
                byte dwlbs = (byte)savegame_fs.ReadByte();
                int dwlbs2 = (byte)((dwlbs & 4) >> 2);
                if (dwlbs2 == 1)
                    checkBoxDWBallS.Checked = true;
                if (dwlbs2 == 0)
                    checkBoxDWBallS.Checked = false;

                // Luiginary Ball: Hammer Check
                savegame_br.BaseStream.Position = 0x2;
                byte dwlbh = (byte)savegame_fs.ReadByte();
                int dwlbh2 = (byte)((dwlbh & 8) >> 3);
                if (dwlbh2 == 1)
                    checkBoxDWBallH.Checked = true;
                if (dwlbh2 == 0)
                    checkBoxDWBallH.Checked = false;

                // Luiginay Dropping Check
                savegame_br.BaseStream.Position = 0x2;
                byte dwld = (byte)savegame_fs.ReadByte();
                int dwld2 = (byte)((dwld & 16) >> 4);
                if (dwld2 == 1)
                    checkBoxDWDrop.Checked = true;
                if (dwld2 == 0)
                    checkBoxDWDrop.Checked = false;

                // Luiginary Antigravity Wallkick Check
                savegame_br.BaseStream.Position = 0x2;
                byte dwlaw = (byte)savegame_fs.ReadByte();
                int dwlaw2 = (byte)((dwlaw & 32) >> 5);
                if (dwlaw2 == 1)
                    checkBoxDWAntigrav.Checked = true;
                if (dwlaw2 == 0)
                    checkBoxDWAntigrav.Checked = false;

                // Allow Pausing Check
                savegame_br.BaseStream.Position = 0x2;
                byte allowpausing = (byte)savegame_fs.ReadByte();
                int allowpausing2 = (byte)((allowpausing & 64) >> 6);
                if (allowpausing2 == 1)
                    checkBoxAllowPausing.Checked = true;
                if (allowpausing2 == 0)
                    checkBoxAllowPausing.Checked = false;

                // Hard Mode Check
                savegame_br.BaseStream.Position = 0x1;
                byte hardmode = (byte)savegame_fs.ReadByte();
                int hardmode2 = (byte)((hardmode & 2) >> 1);
                if (hardmode2 == 1)
                    checkBoxHardMode.Checked = true;
                if (hardmode2 == 0)
                    checkBoxHardMode.Checked = false;

                // Have Badges Check
                savegame_br.BaseStream.Position = 0x3;
                byte havebadges = (byte)savegame_fs.ReadByte();
                int havebadges2 = (byte)((havebadges & 32) >> 5);
                if (havebadges2 == 1)
                    checkBoxHaveBadges.Checked = true;
                if (havebadges2 == 0)
                    checkBoxHaveBadges.Checked = false;

                // NBC Unlock Flag Check
                savegame_br.BaseStream.Position = 0x307;
                byte nbcunlockflag = (byte)savegame_fs.ReadByte();
                int nbcunlockflag2 = (byte)((nbcunlockflag & 64) >> 6);
                if (nbcunlockflag2 == 1)
                    checkBoxNBCUnlockFlag.Checked = true;
                if (nbcunlockflag2 == 0)
                    checkBoxNBCUnlockFlag.Checked = false;

                // NBC Unlock Flag HIDDEN TEXT BOX text
                savegame_br.BaseStream.Position = 0x307;
                byte nbcunlockflaghtb = (byte)savegame_fs.ReadByte();
                int nbcunlockflaghtb2 = (byte)(nbcunlockflaghtb);
                numericRONBCUnlock.Text = (nbcunlockflaghtb2.ToString());

                // Real World Abilities HIDDEN TEXT BOX text
                savegame_br.BaseStream.Position = 0x0;
                byte rwabhtb = (byte)savegame_fs.ReadByte();
                int rwabhtb2 = (byte)(rwabhtb);
                numericRORWAb.Text = (rwabhtb2.ToString());

                // Dream World Abilities HIDDEN TEXT BOX text
                savegame_br.BaseStream.Position = 0x1;
                byte[] dwabhtb = savegame_br.ReadBytes(2);
                int dwabhtb2 = BitConverter.ToInt16(dwabhtb, 0);
                numericRODWAb.Text = (dwabhtb2.ToString());

                // Mario Current HP
                savegame_br.BaseStream.Position = 0x74E;
                byte[] mariocurrenthp = savegame_br.ReadBytes(2);
                int mariocurrenthp2 = BitConverter.ToInt16(mariocurrenthp, 0);
                numericMCurHP.Text = (mariocurrenthp2.ToString());

                // Mario Current BP
                savegame_br.BaseStream.Position = 0x750;
                byte[] mariocurrentbp = savegame_br.ReadBytes(2);
                int mariocurrentbp2 = BitConverter.ToInt16(mariocurrentbp, 0);
                numericMCurBP.Text = (mariocurrentbp2.ToString());

                // Mario Max HP
                savegame_br.BaseStream.Position = 0x752;
                byte[] mariomaxhp = savegame_br.ReadBytes(2);
                int mariomaxhp2 = BitConverter.ToInt16(mariomaxhp, 0);
                numericMMaxHP.Text = (mariomaxhp2.ToString());

                // Mario Max BP
                savegame_br.BaseStream.Position = 0x754;
                byte[] mariomaxbp = savegame_br.ReadBytes(2);
                int mariomaxbp2 = BitConverter.ToInt16(mariomaxbp, 0);
                numericMMaxBP.Text = (mariomaxbp2.ToString());

                // Mario Power
                savegame_br.BaseStream.Position = 0x756;
                byte[] mariopow = savegame_br.ReadBytes(2);
                int mariopow2 = BitConverter.ToInt16(mariopow, 0);
                numericMPower.Text = (mariopow2.ToString());

                // Mario Defense
                savegame_br.BaseStream.Position = 0x758;
                byte[] mariodef = savegame_br.ReadBytes(2);
                int mariodef2 = BitConverter.ToInt16(mariodef, 0);
                numericMDef.Text = (mariodef2.ToString());

                // Mario Speed
                savegame_br.BaseStream.Position = 0x75A;
                byte[] mariospeed = savegame_br.ReadBytes(2);
                int mariospeed2 = BitConverter.ToInt16(mariospeed, 0);
                numericMSpeed.Text = (mariospeed2.ToString());

                // Mario Stache
                savegame_br.BaseStream.Position = 0x75C;
                byte[] mariostache = savegame_br.ReadBytes(2);
                int mariostache2 = BitConverter.ToInt16(mariostache, 0);
                numericMStache.Text = (mariostache2.ToString());

                // Mario Max HP Bean
                savegame_br.BaseStream.Position = 0x75E;
                byte[] mariomaxhpbean = savegame_br.ReadBytes(2);
                int mariomaxhpbean2 = BitConverter.ToInt16(mariomaxhpbean, 0);
                numericMBeanHP.Text = (mariomaxhpbean2.ToString());

                // Mario Max HP Level-up Roulette
                savegame_br.BaseStream.Position = 0x760;
                byte[] mariomaxhplvlup = savegame_br.ReadBytes(2);
                int mariomaxhplvlup2 = BitConverter.ToInt16(mariomaxhplvlup, 0);
                numericMLvlUpHP.Text = (mariomaxhplvlup2.ToString());

                // Mario Max BP Bean
                savegame_br.BaseStream.Position = 0x762;
                byte[] mariomaxbpbean = savegame_br.ReadBytes(2);
                int mariomaxbpbean2 = BitConverter.ToInt16(mariomaxbpbean, 0);
                numericMBeanBP.Text = (mariomaxbpbean2.ToString());

                // Mario Max BP Level-up Roulette
                savegame_br.BaseStream.Position = 0x764;
                byte[] mariomaxbplvlup = savegame_br.ReadBytes(2);
                int mariomaxbplvlup2 = BitConverter.ToInt16(mariomaxbplvlup, 0);
                numericMLvlUpBP.Text = (mariomaxbplvlup2.ToString());

                // Mario Power Bean
                savegame_br.BaseStream.Position = 0x766;
                byte[] mariopowbean = savegame_br.ReadBytes(2);
                int mariopowbean2 = BitConverter.ToInt16(mariopowbean, 0);
                numericMBeanPow.Text = (mariopowbean2.ToString());

                // Mario Power Level-up Roulette
                savegame_br.BaseStream.Position = 0x768;
                byte[] mariopowlvlup = savegame_br.ReadBytes(2);
                int mariopowlvlup2 = BitConverter.ToInt16(mariopowlvlup, 0);
                numericMLvlUpPow.Text = (mariopowlvlup2.ToString());

                // Mario Defense Bean
                savegame_br.BaseStream.Position = 0x76A;
                byte[] mariodefbean = savegame_br.ReadBytes(2);
                int mariodefbean2 = BitConverter.ToInt16(mariodefbean, 0);
                numericMBeanDef.Text = (mariodefbean2.ToString());

                // Mario Defense Level-up Roulette
                savegame_br.BaseStream.Position = 0x76C;
                byte[] mariodeflvlup = savegame_br.ReadBytes(2);
                int mariodeflvlup2 = BitConverter.ToInt16(mariodeflvlup, 0);
                numericMLvlUpDef.Text = (mariodeflvlup2.ToString());

                // Mario Speed Bean
                savegame_br.BaseStream.Position = 0x76E;
                byte[] mariospeedbean = savegame_br.ReadBytes(2);
                int mariospeedbean2 = BitConverter.ToInt16(mariospeedbean, 0);
                numericMBeanSpeed.Text = (mariospeedbean2.ToString());

                // Mario Speed Level-up Roulette
                savegame_br.BaseStream.Position = 0x770;
                byte[] mariospeedlvlup = savegame_br.ReadBytes(2);
                int mariospeedlvlup2 = BitConverter.ToInt16(mariospeedlvlup, 0);
                numericMLvlUpSpeed.Text = (mariospeedlvlup2.ToString());

                // Mario Stache Bean
                savegame_br.BaseStream.Position = 0x772;
                byte[] mariostachebean = savegame_br.ReadBytes(2);
                int mariostachebean2 = BitConverter.ToInt16(mariostachebean, 0);
                numericMBeanStache.Text = (mariostachebean2.ToString());

                // Mario Stache Level-up Roulette
                savegame_br.BaseStream.Position = 0x774;
                byte[] mariostachelvlup = savegame_br.ReadBytes(2);
                int mariostachelvlup2 = BitConverter.ToInt16(mariostachelvlup, 0);
                numericMLvlUpStache.Text = (mariostachelvlup2.ToString());

                // Mario Level
                savegame_br.BaseStream.Position = 0x77B;
                byte mariolevel = (byte)savegame_fs.ReadByte();
                numericMLevel.Text = (mariolevel.ToString());

                // Mario Experience 1
                savegame_br.BaseStream.Position = 0x778;
                byte[] marioexperience1 = savegame_br.ReadBytes(2);
                int marioexperience12 = BitConverter.ToInt16(marioexperience1, 0);
                numericMExperienceHidden1.Text = (marioexperience12.ToString());

                // Mario Experience 2
                savegame_br.BaseStream.Position = 0x77A;
                byte marioexperience2 = (byte)savegame_fs.ReadByte();
                numericMExperienceHidden2.Text = (marioexperience2.ToString());

                // Mario Shell Bonus Selection
                savegame_br.BaseStream.Position = 0x78C;
                byte mariobonus1 = (byte)savegame_fs.ReadByte();
                savegame_br.BaseStream.Position = 0x78D;
                byte mariobonus1check = (byte)savegame_fs.ReadByte();
                if (mariobonus1check == 0)
                    comboBoxMShellBonus.SelectedIndex = 0;
                else if (mariobonus1 == 0)
                    comboBoxMShellBonus.SelectedIndex = 1;
                if (mariobonus1 == 1)
                    comboBoxMShellBonus.SelectedIndex = 2;
                if (mariobonus1 == 2)
                    comboBoxMShellBonus.SelectedIndex = 3;
                if (mariobonus1 == 3)
                    comboBoxMShellBonus.SelectedIndex = 4;
                if (mariobonus1 == 4)
                    comboBoxMShellBonus.SelectedIndex = 5;
                if (mariobonus1 == 5)
                    comboBoxMShellBonus.SelectedIndex = 6;
                if (mariobonus1 == 6)
                    comboBoxMShellBonus.SelectedIndex = 7;
                if (mariobonus1 == 7)
                    comboBoxMShellBonus.SelectedIndex = 8;
                if (mariobonus1 == 8)
                    comboBoxMShellBonus.SelectedIndex = 9;
                if (mariobonus1 == 9)
                    comboBoxMShellBonus.SelectedIndex = 10;
                if (mariobonus1 == 10)
                    comboBoxMShellBonus.SelectedIndex = 11;
                if (mariobonus1 == 11)
                    comboBoxMShellBonus.SelectedIndex = 12;
                if (mariobonus1 == 12)
                    comboBoxMShellBonus.SelectedIndex = 13;
                if (mariobonus1 == 13)
                    comboBoxMShellBonus.SelectedIndex = 14;
                if (mariobonus1 == 14)
                    comboBoxMShellBonus.SelectedIndex = 15;

                // Mario Flower Bonus Selection
                savegame_br.BaseStream.Position = 0x78E;
                byte mariobonus2 = (byte)savegame_fs.ReadByte();
                savegame_br.BaseStream.Position = 0x78F;
                byte mariobonus2check = (byte)savegame_fs.ReadByte();
                if (mariobonus2check == 0)
                    comboBoxMFlowerBonus.SelectedIndex = 0;
                else if (mariobonus2 == 0)
                    comboBoxMFlowerBonus.SelectedIndex = 1;
                if (mariobonus2 == 1)
                    comboBoxMFlowerBonus.SelectedIndex = 2;
                if (mariobonus2 == 2)
                    comboBoxMFlowerBonus.SelectedIndex = 3;
                if (mariobonus2 == 3)
                    comboBoxMFlowerBonus.SelectedIndex = 4;
                if (mariobonus2 == 4)
                    comboBoxMFlowerBonus.SelectedIndex = 5;
                if (mariobonus2 == 5)
                    comboBoxMFlowerBonus.SelectedIndex = 6;
                if (mariobonus2 == 6)
                    comboBoxMFlowerBonus.SelectedIndex = 7;
                if (mariobonus2 == 7)
                    comboBoxMFlowerBonus.SelectedIndex = 8;
                if (mariobonus2 == 8)
                    comboBoxMFlowerBonus.SelectedIndex = 9;
                if (mariobonus2 == 9)
                    comboBoxMFlowerBonus.SelectedIndex = 10;
                if (mariobonus2 == 10)
                    comboBoxMFlowerBonus.SelectedIndex = 11;
                if (mariobonus2 == 11)
                    comboBoxMFlowerBonus.SelectedIndex = 12;
                if (mariobonus2 == 12)
                    comboBoxMFlowerBonus.SelectedIndex = 13;
                if (mariobonus2 == 13)
                    comboBoxMFlowerBonus.SelectedIndex = 14;
                if (mariobonus2 == 14)
                    comboBoxMFlowerBonus.SelectedIndex = 15;

                // Mario Star Bonus Selection
                savegame_br.BaseStream.Position = 0x790;
                byte mariobonus3 = (byte)savegame_fs.ReadByte();
                savegame_br.BaseStream.Position = 0x791;
                byte mariobonus3check = (byte)savegame_fs.ReadByte();
                if (mariobonus3check == 0)
                    comboBoxMStarBonus.SelectedIndex = 0;
                else if (mariobonus3 == 0)
                    comboBoxMStarBonus.SelectedIndex = 1;
                if (mariobonus3 == 1)
                    comboBoxMStarBonus.SelectedIndex = 2;
                if (mariobonus3 == 2)
                    comboBoxMStarBonus.SelectedIndex = 3;
                if (mariobonus3 == 3)
                    comboBoxMStarBonus.SelectedIndex = 4;
                if (mariobonus3 == 4)
                    comboBoxMStarBonus.SelectedIndex = 5;
                if (mariobonus3 == 5)
                    comboBoxMStarBonus.SelectedIndex = 6;
                if (mariobonus3 == 6)
                    comboBoxMStarBonus.SelectedIndex = 7;
                if (mariobonus3 == 7)
                    comboBoxMStarBonus.SelectedIndex = 8;
                if (mariobonus3 == 8)
                    comboBoxMStarBonus.SelectedIndex = 9;
                if (mariobonus3 == 9)
                    comboBoxMStarBonus.SelectedIndex = 10;
                if (mariobonus3 == 10)
                    comboBoxMStarBonus.SelectedIndex = 11;
                if (mariobonus3 == 11)
                    comboBoxMStarBonus.SelectedIndex = 12;
                if (mariobonus3 == 12)
                    comboBoxMStarBonus.SelectedIndex = 13;
                if (mariobonus3 == 13)
                    comboBoxMStarBonus.SelectedIndex = 14;
                if (mariobonus3 == 14)
                    comboBoxMStarBonus.SelectedIndex = 15;

                // Mario Rainbow Bonus Selection
                savegame_br.BaseStream.Position = 0x792;
                byte mariobonus4 = (byte)savegame_fs.ReadByte();
                savegame_br.BaseStream.Position = 0x793;
                byte mariobonus4check = (byte)savegame_fs.ReadByte();
                if (mariobonus4check == 0)
                    comboBoxMRainbowBonus.SelectedIndex = 0;
                else if (mariobonus4 == 0)
                    comboBoxMRainbowBonus.SelectedIndex = 1;
                if (mariobonus4 == 1)
                    comboBoxMRainbowBonus.SelectedIndex = 2;
                if (mariobonus4 == 2)
                    comboBoxMRainbowBonus.SelectedIndex = 3;
                if (mariobonus4 == 3)
                    comboBoxMRainbowBonus.SelectedIndex = 4;
                if (mariobonus4 == 4)
                    comboBoxMRainbowBonus.SelectedIndex = 5;
                if (mariobonus4 == 5)
                    comboBoxMRainbowBonus.SelectedIndex = 6;
                if (mariobonus4 == 6)
                    comboBoxMRainbowBonus.SelectedIndex = 7;
                if (mariobonus4 == 7)
                    comboBoxMRainbowBonus.SelectedIndex = 8;
                if (mariobonus4 == 8)
                    comboBoxMRainbowBonus.SelectedIndex = 9;
                if (mariobonus4 == 9)
                    comboBoxMRainbowBonus.SelectedIndex = 10;
                if (mariobonus4 == 10)
                    comboBoxMRainbowBonus.SelectedIndex = 11;
                if (mariobonus4 == 11)
                    comboBoxMRainbowBonus.SelectedIndex = 12;
                if (mariobonus4 == 12)
                    comboBoxMRainbowBonus.SelectedIndex = 13;
                if (mariobonus4 == 13)
                    comboBoxMRainbowBonus.SelectedIndex = 14;
                if (mariobonus4 == 14)
                    comboBoxMRainbowBonus.SelectedIndex = 15;

                // Mario Extra Bonus Selection
                savegame_br.BaseStream.Position = 0x794;
                byte mariobonus5 = (byte)savegame_fs.ReadByte();
                savegame_br.BaseStream.Position = 0x795;
                byte mariobonus5check = (byte)savegame_fs.ReadByte();
                if (mariobonus5check == 0)
                    comboBoxMExtraBonus.SelectedIndex = 0;
                else if (mariobonus5 == 0)
                    comboBoxMExtraBonus.SelectedIndex = 1;
                if (mariobonus5 == 1)
                    comboBoxMExtraBonus.SelectedIndex = 2;
                if (mariobonus5 == 2)
                    comboBoxMExtraBonus.SelectedIndex = 3;
                if (mariobonus5 == 3)
                    comboBoxMExtraBonus.SelectedIndex = 4;
                if (mariobonus5 == 4)
                    comboBoxMExtraBonus.SelectedIndex = 5;
                if (mariobonus5 == 5)
                    comboBoxMExtraBonus.SelectedIndex = 6;
                if (mariobonus5 == 6)
                    comboBoxMExtraBonus.SelectedIndex = 7;
                if (mariobonus5 == 7)
                    comboBoxMExtraBonus.SelectedIndex = 8;
                if (mariobonus5 == 8)
                    comboBoxMExtraBonus.SelectedIndex = 9;
                if (mariobonus5 == 9)
                    comboBoxMExtraBonus.SelectedIndex = 10;
                if (mariobonus5 == 10)
                    comboBoxMExtraBonus.SelectedIndex = 11;
                if (mariobonus5 == 11)
                    comboBoxMExtraBonus.SelectedIndex = 12;
                if (mariobonus5 == 12)
                    comboBoxMExtraBonus.SelectedIndex = 13;
                if (mariobonus5 == 13)
                    comboBoxMExtraBonus.SelectedIndex = 14;
                if (mariobonus5 == 14)
                    comboBoxMExtraBonus.SelectedIndex = 15;

                // Gear Slot +1 check
                savegame_br.BaseStream.Position = 0x77F;
                byte mgsp1c = (byte)savegame_fs.ReadByte();
                int mgsp1c2 = (byte)((mgsp1c) >> 4);
                numericROMGearSlot.Value = mgsp1c;
                if (mgsp1c2 == 3)
                    checkBoxMGearSlot1.Checked = false;
                if (mgsp1c2 == 3)
                    checkBoxMGearSlot2.Checked = false;
                else if (mgsp1c2 == 4)
                    checkBoxMGearSlot1.Checked = true;
                else if (mgsp1c2 == 5)
                    checkBoxMGearSlot1.Checked = true;
                if (mgsp1c2 == 5)
                    checkBoxMGearSlot2.Checked = true;

                // Badge Slot Universal Counter
                savegame_br.BaseStream.Position = 0xA09;
                byte badgeslotcount = (byte)savegame_fs.ReadByte();
                numericUniversalBadgeCount1.Value = badgeslotcount;

                // Luigi Current HP
                savegame_br.BaseStream.Position = 0x836;
                byte[] Luigicurrenthp = savegame_br.ReadBytes(2);
                int Luigicurrenthp2 = BitConverter.ToInt16(Luigicurrenthp, 0);
                numericLCurHP.Text = (Luigicurrenthp2.ToString());

                // Luigi Current BP
                savegame_br.BaseStream.Position = 0x838;
                byte[] Luigicurrentbp = savegame_br.ReadBytes(2);
                int Luigicurrentbp2 = BitConverter.ToInt16(Luigicurrentbp, 0);
                numericLCurBP.Text = (Luigicurrentbp2.ToString());

                // Luigi Max HP
                savegame_br.BaseStream.Position = 0x83A;
                byte[] Luigimaxhp = savegame_br.ReadBytes(2);
                int Luigimaxhp2 = BitConverter.ToInt16(Luigimaxhp, 0);
                numericLMaxHP.Text = (Luigimaxhp2.ToString());

                // Luigi Max BP
                savegame_br.BaseStream.Position = 0x83C;
                byte[] Luigimaxbp = savegame_br.ReadBytes(2);
                int Luigimaxbp2 = BitConverter.ToInt16(Luigimaxbp, 0);
                numericLMaxBP.Text = (Luigimaxbp2.ToString());

                // Luigi Power
                savegame_br.BaseStream.Position = 0x83E;
                byte[] Luigipow = savegame_br.ReadBytes(2);
                int Luigipow2 = BitConverter.ToInt16(Luigipow, 0);
                numericLPow.Text = (Luigipow2.ToString());

                // Luigi Defense
                savegame_br.BaseStream.Position = 0x840;
                byte[] Luigidef = savegame_br.ReadBytes(2);
                int Luigidef2 = BitConverter.ToInt16(Luigidef, 0);
                numericLDef.Text = (Luigidef2.ToString());

                // Luigi Speed
                savegame_br.BaseStream.Position = 0x842;
                byte[] Luigispeed = savegame_br.ReadBytes(2);
                int Luigispeed2 = BitConverter.ToInt16(Luigispeed, 0);
                numericLSpeed.Text = (Luigispeed2.ToString());

                // Luigi Stache
                savegame_br.BaseStream.Position = 0x844;
                byte[] Luigistache = savegame_br.ReadBytes(2);
                int Luigistache2 = BitConverter.ToInt16(Luigistache, 0);
                numericLStache.Text = (Luigistache2.ToString());

                // Luigi Max HP Bean
                savegame_br.BaseStream.Position = 0x846;
                byte[] Luigimaxhpbean = savegame_br.ReadBytes(2);
                int Luigimaxhpbean2 = BitConverter.ToInt16(Luigimaxhpbean, 0);
                numericLBeanHP.Text = (Luigimaxhpbean2.ToString());

                // Luigi Max HP Level-up Roulette
                savegame_br.BaseStream.Position = 0x848;
                byte[] Luigimaxhplvlup = savegame_br.ReadBytes(2);
                int Luigimaxhplvlup2 = BitConverter.ToInt16(Luigimaxhplvlup, 0);
                numericLLvlUpHP.Text = (Luigimaxhplvlup2.ToString());

                // Luigi Max BP Bean
                savegame_br.BaseStream.Position = 0x84A;
                byte[] Luigimaxbpbean = savegame_br.ReadBytes(2);
                int Luigimaxbpbean2 = BitConverter.ToInt16(Luigimaxbpbean, 0);
                numericLBeanBP.Text = (Luigimaxbpbean2.ToString());

                // Luigi Max BP Level-up Roulette
                savegame_br.BaseStream.Position = 0x84C;
                byte[] Luigimaxbplvlup = savegame_br.ReadBytes(2);
                int Luigimaxbplvlup2 = BitConverter.ToInt16(Luigimaxbplvlup, 0);
                numericLLvlUpBP.Text = (Luigimaxbplvlup2.ToString());

                // Luigi Power Bean
                savegame_br.BaseStream.Position = 0x84E;
                byte[] Luigipowbean = savegame_br.ReadBytes(2);
                int Luigipowbean2 = BitConverter.ToInt16(Luigipowbean, 0);
                numericLBeanPow.Text = (Luigipowbean2.ToString());

                // Luigi Power Level-up Roulette
                savegame_br.BaseStream.Position = 0x850;
                byte[] Luigipowlvlup = savegame_br.ReadBytes(2);
                int Luigipowlvlup2 = BitConverter.ToInt16(Luigipowlvlup, 0);
                numericLLvlUpPow.Text = (Luigipowlvlup2.ToString());

                // Luigi Defense Bean
                savegame_br.BaseStream.Position = 0x852;
                byte[] Luigidefbean = savegame_br.ReadBytes(2);
                int Luigidefbean2 = BitConverter.ToInt16(Luigidefbean, 0);
                numericLBeanDef.Text = (Luigidefbean2.ToString());

                // Luigi Defense Level-up Roulette
                savegame_br.BaseStream.Position = 0x854;
                byte[] Luigideflvlup = savegame_br.ReadBytes(2);
                int Luigideflvlup2 = BitConverter.ToInt16(Luigideflvlup, 0);
                numericLLvlUpDef.Text = (Luigideflvlup2.ToString());

                // Luigi Speed Bean
                savegame_br.BaseStream.Position = 0x856;
                byte[] Luigispeedbean = savegame_br.ReadBytes(2);
                int Luigispeedbean2 = BitConverter.ToInt16(Luigispeedbean, 0);
                numericLBeanSpeed.Text = (Luigispeedbean2.ToString());

                // Luigi Speed Level-up Roulette
                savegame_br.BaseStream.Position = 0x858;
                byte[] Luigispeedlvlup = savegame_br.ReadBytes(2);
                int Luigispeedlvlup2 = BitConverter.ToInt16(Luigispeedlvlup, 0);
                numericLLvlUpSpeed.Text = (Luigispeedlvlup2.ToString());

                // Luigi Stache Bean
                savegame_br.BaseStream.Position = 0x85A;
                byte[] Luigistachebean = savegame_br.ReadBytes(2);
                int Luigistachebean2 = BitConverter.ToInt16(Luigistachebean, 0);
                numericLBeanStache.Text = (Luigistachebean2.ToString());

                // Luigi Stache Level-up Roulette
                savegame_br.BaseStream.Position = 0x85C;
                byte[] Luigistachelvlup = savegame_br.ReadBytes(2);
                int Luigistachelvlup2 = BitConverter.ToInt16(Luigistachelvlup, 0);
                numericLLvlUpStache.Text = (Luigistachelvlup2.ToString());

                // Luigi Level
                savegame_br.BaseStream.Position = 0x863;
                byte Luigilevel = (byte)savegame_fs.ReadByte();
                numericLLevel.Text = (Luigilevel.ToString());

                // Luigi Experience 1
                savegame_br.BaseStream.Position = 0x860;
                byte[] Luigiexperience1 = savegame_br.ReadBytes(2);
                int Luigiexperience12 = BitConverter.ToInt16(Luigiexperience1, 0);
                numericLExperienceHidden1.Text = (Luigiexperience12.ToString());

                // Luigi Experience 2
                savegame_br.BaseStream.Position = 0x862;
                byte Luigiexperience2 = (byte)savegame_fs.ReadByte();
                numericLExperienceHidden2.Text = (Luigiexperience2.ToString());

                // Luigi Shell Bonus Selection
                savegame_br.BaseStream.Position = 0x874;
                byte Luigibonus1 = (byte)savegame_fs.ReadByte();
                savegame_br.BaseStream.Position = 0x875;
                byte Luigibonus1check = (byte)savegame_fs.ReadByte();
                if (Luigibonus1check == 0)
                    comboBoxLShellBonus.SelectedIndex = 0;
                else if (Luigibonus1 == 0)
                    comboBoxLShellBonus.SelectedIndex = 1;
                if (Luigibonus1 == 1)
                    comboBoxLShellBonus.SelectedIndex = 2;
                if (Luigibonus1 == 2)
                    comboBoxLShellBonus.SelectedIndex = 3;
                if (Luigibonus1 == 3)
                    comboBoxLShellBonus.SelectedIndex = 4;
                if (Luigibonus1 == 4)
                    comboBoxLShellBonus.SelectedIndex = 5;
                if (Luigibonus1 == 5)
                    comboBoxLShellBonus.SelectedIndex = 6;
                if (Luigibonus1 == 6)
                    comboBoxLShellBonus.SelectedIndex = 7;
                if (Luigibonus1 == 7)
                    comboBoxLShellBonus.SelectedIndex = 8;
                if (Luigibonus1 == 8)
                    comboBoxLShellBonus.SelectedIndex = 9;
                if (Luigibonus1 == 9)
                    comboBoxLShellBonus.SelectedIndex = 10;
                if (Luigibonus1 == 10)
                    comboBoxLShellBonus.SelectedIndex = 11;
                if (Luigibonus1 == 11)
                    comboBoxLShellBonus.SelectedIndex = 12;
                if (Luigibonus1 == 12)
                    comboBoxLShellBonus.SelectedIndex = 13;
                if (Luigibonus1 == 13)
                    comboBoxLShellBonus.SelectedIndex = 14;
                if (Luigibonus1 == 14)
                    comboBoxLShellBonus.SelectedIndex = 15;

                // Luigi Flower Bonus Selection
                savegame_br.BaseStream.Position = 0x876;
                byte Luigibonus2 = (byte)savegame_fs.ReadByte();
                savegame_br.BaseStream.Position = 0x877;
                byte Luigibonus2check = (byte)savegame_fs.ReadByte();
                if (Luigibonus2check == 0)
                    comboBoxLFlowerBonus.SelectedIndex = 0;
                else if (Luigibonus2 == 0)
                    comboBoxLFlowerBonus.SelectedIndex = 1;
                if (Luigibonus2 == 1)
                    comboBoxLFlowerBonus.SelectedIndex = 2;
                if (Luigibonus2 == 2)
                    comboBoxLFlowerBonus.SelectedIndex = 3;
                if (Luigibonus2 == 3)
                    comboBoxLFlowerBonus.SelectedIndex = 4;
                if (Luigibonus2 == 4)
                    comboBoxLFlowerBonus.SelectedIndex = 5;
                if (Luigibonus2 == 5)
                    comboBoxLFlowerBonus.SelectedIndex = 6;
                if (Luigibonus2 == 6)
                    comboBoxLFlowerBonus.SelectedIndex = 7;
                if (Luigibonus2 == 7)
                    comboBoxLFlowerBonus.SelectedIndex = 8;
                if (Luigibonus2 == 8)
                    comboBoxLFlowerBonus.SelectedIndex = 9;
                if (Luigibonus2 == 9)
                    comboBoxLFlowerBonus.SelectedIndex = 10;
                if (Luigibonus2 == 10)
                    comboBoxLFlowerBonus.SelectedIndex = 11;
                if (Luigibonus2 == 11)
                    comboBoxLFlowerBonus.SelectedIndex = 12;
                if (Luigibonus2 == 12)
                    comboBoxLFlowerBonus.SelectedIndex = 13;
                if (Luigibonus2 == 13)
                    comboBoxLFlowerBonus.SelectedIndex = 14;
                if (Luigibonus2 == 14)
                    comboBoxLFlowerBonus.SelectedIndex = 15;

                // Luigi Star Bonus Selection
                savegame_br.BaseStream.Position = 0x878;
                byte Luigibonus3 = (byte)savegame_fs.ReadByte();
                savegame_br.BaseStream.Position = 0x879;
                byte Luigibonus3check = (byte)savegame_fs.ReadByte();
                if (Luigibonus3check == 0)
                    comboBoxLStarBonus.SelectedIndex = 0;
                else if (Luigibonus3 == 0)
                    comboBoxLStarBonus.SelectedIndex = 1;
                if (Luigibonus3 == 1)
                    comboBoxLStarBonus.SelectedIndex = 2;
                if (Luigibonus3 == 2)
                    comboBoxLStarBonus.SelectedIndex = 3;
                if (Luigibonus3 == 3)
                    comboBoxLStarBonus.SelectedIndex = 4;
                if (Luigibonus3 == 4)
                    comboBoxLStarBonus.SelectedIndex = 5;
                if (Luigibonus3 == 5)
                    comboBoxLStarBonus.SelectedIndex = 6;
                if (Luigibonus3 == 6)
                    comboBoxLStarBonus.SelectedIndex = 7;
                if (Luigibonus3 == 7)
                    comboBoxLStarBonus.SelectedIndex = 8;
                if (Luigibonus3 == 8)
                    comboBoxLStarBonus.SelectedIndex = 9;
                if (Luigibonus3 == 9)
                    comboBoxLStarBonus.SelectedIndex = 10;
                if (Luigibonus3 == 10)
                    comboBoxLStarBonus.SelectedIndex = 11;
                if (Luigibonus3 == 11)
                    comboBoxLStarBonus.SelectedIndex = 12;
                if (Luigibonus3 == 12)
                    comboBoxLStarBonus.SelectedIndex = 13;
                if (Luigibonus3 == 13)
                    comboBoxLStarBonus.SelectedIndex = 14;
                if (Luigibonus3 == 14)
                    comboBoxLStarBonus.SelectedIndex = 15;

                // Luigi Rainbow Bonus Selection
                savegame_br.BaseStream.Position = 0x87A;
                byte Luigibonus4 = (byte)savegame_fs.ReadByte();
                savegame_br.BaseStream.Position = 0x87B;
                byte Luigibonus4check = (byte)savegame_fs.ReadByte();
                if (Luigibonus4check == 0)
                    comboBoxLRainbowBonus.SelectedIndex = 0;
                else if (Luigibonus4 == 0)
                    comboBoxLRainbowBonus.SelectedIndex = 1;
                if (Luigibonus4 == 1)
                    comboBoxLRainbowBonus.SelectedIndex = 2;
                if (Luigibonus4 == 2)
                    comboBoxLRainbowBonus.SelectedIndex = 3;
                if (Luigibonus4 == 3)
                    comboBoxLRainbowBonus.SelectedIndex = 4;
                if (Luigibonus4 == 4)
                    comboBoxLRainbowBonus.SelectedIndex = 5;
                if (Luigibonus4 == 5)
                    comboBoxLRainbowBonus.SelectedIndex = 6;
                if (Luigibonus4 == 6)
                    comboBoxLRainbowBonus.SelectedIndex = 7;
                if (Luigibonus4 == 7)
                    comboBoxLRainbowBonus.SelectedIndex = 8;
                if (Luigibonus4 == 8)
                    comboBoxLRainbowBonus.SelectedIndex = 9;
                if (Luigibonus4 == 9)
                    comboBoxLRainbowBonus.SelectedIndex = 10;
                if (Luigibonus4 == 10)
                    comboBoxLRainbowBonus.SelectedIndex = 11;
                if (Luigibonus4 == 11)
                    comboBoxLRainbowBonus.SelectedIndex = 12;
                if (Luigibonus4 == 12)
                    comboBoxLRainbowBonus.SelectedIndex = 13;
                if (Luigibonus4 == 13)
                    comboBoxLRainbowBonus.SelectedIndex = 14;
                if (Luigibonus4 == 14)
                    comboBoxLRainbowBonus.SelectedIndex = 15;

                // Luigi Extra Bonus Selection
                savegame_br.BaseStream.Position = 0x87C;
                byte Luigibonus5 = (byte)savegame_fs.ReadByte();
                savegame_br.BaseStream.Position = 0x87D;
                byte Luigibonus5check = (byte)savegame_fs.ReadByte();
                if (Luigibonus5check == 0)
                    comboBoxLExtraBonus.SelectedIndex = 0;
                else if (Luigibonus5 == 0)
                    comboBoxLExtraBonus.SelectedIndex = 1;
                if (Luigibonus5 == 1)
                    comboBoxLExtraBonus.SelectedIndex = 2;
                if (Luigibonus5 == 2)
                    comboBoxLExtraBonus.SelectedIndex = 3;
                if (Luigibonus5 == 3)
                    comboBoxLExtraBonus.SelectedIndex = 4;
                if (Luigibonus5 == 4)
                    comboBoxLExtraBonus.SelectedIndex = 5;
                if (Luigibonus5 == 5)
                    comboBoxLExtraBonus.SelectedIndex = 6;
                if (Luigibonus5 == 6)
                    comboBoxLExtraBonus.SelectedIndex = 7;
                if (Luigibonus5 == 7)
                    comboBoxLExtraBonus.SelectedIndex = 8;
                if (Luigibonus5 == 8)
                    comboBoxLExtraBonus.SelectedIndex = 9;
                if (Luigibonus5 == 9)
                    comboBoxLExtraBonus.SelectedIndex = 10;
                if (Luigibonus5 == 10)
                    comboBoxLExtraBonus.SelectedIndex = 11;
                if (Luigibonus5 == 11)
                    comboBoxLExtraBonus.SelectedIndex = 12;
                if (Luigibonus5 == 12)
                    comboBoxLExtraBonus.SelectedIndex = 13;
                if (Luigibonus5 == 13)
                    comboBoxLExtraBonus.SelectedIndex = 14;
                if (Luigibonus5 == 14)
                    comboBoxLExtraBonus.SelectedIndex = 15;

                // Luigi Gear Slot +1 check
                savegame_br.BaseStream.Position = 0x867;
                byte lgsp1c = (byte)savegame_fs.ReadByte();
                int lgsp1c2 = (byte)((lgsp1c) >> 4);
                numericROLGearSlot.Value = lgsp1c;
                if (lgsp1c2 == 3)
                    checkBoxLGearSlot1.Checked = false;
                if (lgsp1c2 == 3)
                    checkBoxLGearSlot2.Checked = false;
                else if (lgsp1c2 == 4)
                    checkBoxLGearSlot1.Checked = true;
                else if (lgsp1c2 == 5)
                    checkBoxLGearSlot1.Checked = true;
                if (lgsp1c2 == 5)
                    checkBoxLGearSlot2.Checked = true;
                
                // Money
                savegame_br.BaseStream.Position = 0x91C;
                byte[] money = savegame_br.ReadBytes(4);
                int moneyall = BitConverter.ToInt32(money, 0);
                box_money.Text = (moneyall.ToString());

                // Mushroom Count
                savegame_br.BaseStream.Position = 0x920;
                byte mushroomcount =(byte)savegame_fs.ReadByte();
                numericMushCount.Text = (mushroomcount.ToString());

                // Super Mushroom Count
                savegame_br.BaseStream.Position = 0x921;
                byte supermushroomcount = (byte)savegame_fs.ReadByte();
                numericSuperMushCount.Text = (supermushroomcount.ToString());

                // Ultra Mushroom Count
                savegame_br.BaseStream.Position = 0x922;
                byte ultramushroomcount = (byte)savegame_fs.ReadByte();
                numericUltraMushCount.Text = (ultramushroomcount.ToString());

                // Max Mushroom Count
                savegame_br.BaseStream.Position = 0x923;
                byte maxmushroomcount = (byte)savegame_fs.ReadByte();
                numericMaxMushCount.Text = (maxmushroomcount.ToString());

                // Syrup Jar Count
                savegame_br.BaseStream.Position = 0x928;
                byte syrupcount = (byte)savegame_fs.ReadByte();
                numericSyrupCount.Text = (syrupcount.ToString());

                // Supersyrup Jar Count
                savegame_br.BaseStream.Position = 0x929;
                byte supersyrupcount = (byte)savegame_fs.ReadByte();
                numericSupsyrCount.Text = (supersyrupcount.ToString());

                // Ultrasyrup Jar Count
                savegame_br.BaseStream.Position = 0x92A;
                byte ultrasyrupcount = (byte)savegame_fs.ReadByte();
                numericUltraSyrCount.Text = (ultrasyrupcount.ToString());

                // Max Syrup Jar Count
                savegame_br.BaseStream.Position = 0x92B;
                byte maxsyrupcount = (byte)savegame_fs.ReadByte();
                numericMaxSyrCount.Text = (maxsyrupcount.ToString());

                // Nut Count
                savegame_br.BaseStream.Position = 0x924;
                byte nutcount = (byte)savegame_fs.ReadByte();
                numericNuts.Text = (nutcount.ToString());

                // Super Nut Count
                savegame_br.BaseStream.Position = 0x925;
                byte supernutcount = (byte)savegame_fs.ReadByte();
                numericSuperNuts.Text = (supernutcount.ToString());

                // Ultra Nut Count
                savegame_br.BaseStream.Position = 0x926;
                byte ultranutcount = (byte)savegame_fs.ReadByte();
                numericUltraNuts.Text = (ultranutcount.ToString());

                // Max Nut Count
                savegame_br.BaseStream.Position = 0x927;
                byte maxnutcount = (byte)savegame_fs.ReadByte();
                numericMaxNuts.Text = (maxnutcount.ToString());

                // Candy Count
                savegame_br.BaseStream.Position = 0x92C;
                byte candycount = (byte)savegame_fs.ReadByte();
                numericCandies.Text = (candycount.ToString());

                // Super Candy Count
                savegame_br.BaseStream.Position = 0x92D;
                byte supercandycount = (byte)savegame_fs.ReadByte();
                numericSuperCandies.Text = (supercandycount.ToString());

                // Ultra Candy Count
                savegame_br.BaseStream.Position = 0x92E;
                byte ultracandycount = (byte)savegame_fs.ReadByte();
                numericUltraCandies.Text = (ultracandycount.ToString());

                // Max Candy Count
                savegame_br.BaseStream.Position = 0x92F;
                byte maxcandycount = (byte)savegame_fs.ReadByte();
                numericMaxCandies.Text = (maxcandycount.ToString());

                // 1-Up Mushroom Count
                savegame_br.BaseStream.Position = 0x930;
                byte oneupcount = (byte)savegame_fs.ReadByte();
                numeric1upMush.Text = (oneupcount.ToString());

                // 1-Up Deluxe Count
                savegame_br.BaseStream.Position = 0x931;
                byte oneupdeluxecount = (byte)savegame_fs.ReadByte();
                numeric1upDeluxe.Text = (oneupdeluxecount.ToString());

                // Refreshing Herb Count
                savegame_br.BaseStream.Position = 0x932;
                byte refreshingherbcount = (byte)savegame_fs.ReadByte();
                numericRefreshingHerbs.Text = (refreshingherbcount.ToString());

                // Taunt Ball Count
                savegame_br.BaseStream.Position = 0x939;
                byte tauntballcount = (byte)savegame_fs.ReadByte();
                numericTauntBall.Text = (tauntballcount.ToString());

                // Shock Bomb Count
                savegame_br.BaseStream.Position = 0x93A;
                byte shockbombcount = (byte)savegame_fs.ReadByte();
                numericShockBomb.Text = (shockbombcount.ToString());

                // Boo Biscuit Count
                savegame_br.BaseStream.Position = 0x93B;
                byte boobiscuitcount = (byte)savegame_fs.ReadByte();
                numericBooBiscuit.Text = (boobiscuitcount.ToString());

                // Secret Box Count
                savegame_br.BaseStream.Position = 0x93C;
                byte secretboxcount = (byte)savegame_fs.ReadByte();
                numericSecretBoxes.Text = (secretboxcount.ToString());

                // Heart Bean Count
                savegame_br.BaseStream.Position = 0x933;
                byte heartbeancount = (byte)savegame_fs.ReadByte();
                numericHeartBeans.Text = (heartbeancount.ToString());

                // Bros. Bean Count
                savegame_br.BaseStream.Position = 0x934;
                byte brosbeancount = (byte)savegame_fs.ReadByte();
                numericBrosBeans.Text = (brosbeancount.ToString());

                // Power Bean Count
                savegame_br.BaseStream.Position = 0x935;
                byte powbeancount = (byte)savegame_fs.ReadByte();
                numericPowerBeans.Text = (powbeancount.ToString());

                // Defense Bean Count
                savegame_br.BaseStream.Position = 0x936;
                byte defbeancount = (byte)savegame_fs.ReadByte();
                numericDefenseBeans.Text = (defbeancount.ToString());

                // Speed Bean Count
                savegame_br.BaseStream.Position = 0x937;
                byte speedbeancount = (byte)savegame_fs.ReadByte();
                numericSpeedBeans.Text = (speedbeancount.ToString());

                // Stache Bean Count
                savegame_br.BaseStream.Position = 0x938;
                byte higebeancount = (byte)savegame_fs.ReadByte();
                numericStacheBeans.Text = (higebeancount.ToString());

                // Heart Bean DX Count
                savegame_br.BaseStream.Position = 0x93D;
                byte heartbeandxcount = (byte)savegame_fs.ReadByte();
                numericHeartBeansDX.Text = (heartbeandxcount.ToString());

                // Bros. Bean DX Count
                savegame_br.BaseStream.Position = 0x93E;
                byte brosbeandxcount = (byte)savegame_fs.ReadByte();
                numericBrosBeansDX.Text = (brosbeandxcount.ToString());

                // Power Bean DX Count
                savegame_br.BaseStream.Position = 0x93F;
                byte powbeandxcount = (byte)savegame_fs.ReadByte();
                numericPowerBeansDX.Text = (powbeandxcount.ToString());

                // Defense Bean DX Count
                savegame_br.BaseStream.Position = 0x940;
                byte defbeandxcount = (byte)savegame_fs.ReadByte();
                numericDefenseBeansDX.Text = (defbeandxcount.ToString());

                // Speed Bean DX Count
                savegame_br.BaseStream.Position = 0x941;
                byte speedbeandxcount = (byte)savegame_fs.ReadByte();
                numericSpeedBeansDX.Text = (speedbeandxcount.ToString());

                // Stache Bean DX Count
                savegame_br.BaseStream.Position = 0x942;
                byte higebeandxcount = (byte)savegame_fs.ReadByte();
                numericStacheBeansDX.Text = (higebeandxcount.ToString());

                // Boots 1
                savegame_br.BaseStream.Position = 0x948;
                byte boots1 = (byte)savegame_fs.ReadByte();
                numericBoots1.Text = (boots1.ToString());

                // Boots 2
                savegame_br.BaseStream.Position = 0x949;
                byte boots2 = (byte)savegame_fs.ReadByte();
                numericBoots2.Text = (boots2.ToString());

                // boots 3
                savegame_br.BaseStream.Position = 0x94A;
                byte boots3 = (byte)savegame_fs.ReadByte();
                numericBoots3.Text = (boots3.ToString());

                // boots 4
                savegame_br.BaseStream.Position = 0x94B;
                byte boots4 = (byte)savegame_fs.ReadByte();
                numericBoots4.Text = (boots4.ToString());

                // 
                savegame_br.BaseStream.Position = 0x94C;
                byte boots5 = (byte)savegame_fs.ReadByte();
                numericBoots5.Text = (boots5.ToString());

                // 
                savegame_br.BaseStream.Position = 0x94D;
                byte boots6 = (byte)savegame_fs.ReadByte();
                numericBoots6.Text = (boots6.ToString());

                // 
                savegame_br.BaseStream.Position = 0x94E;
                byte boots7 = (byte)savegame_fs.ReadByte();
                numericBoots7.Text = (boots7.ToString());

                // 
                savegame_br.BaseStream.Position = 0x94F;
                byte boots8 = (byte)savegame_fs.ReadByte();
                numericBoots8.Text = (boots8.ToString());

                // 
                savegame_br.BaseStream.Position = 0x950;
                byte boots9 = (byte)savegame_fs.ReadByte();
                numericBoots9.Text = (boots9.ToString());

                // 
                savegame_br.BaseStream.Position = 0x951;
                byte boots10 = (byte)savegame_fs.ReadByte();
                numericBoots10.Text = (boots10.ToString());

                // 
                savegame_br.BaseStream.Position = 0x952;
                byte boots11 = (byte)savegame_fs.ReadByte();
                numericBoots11.Text = (boots11.ToString());

                // 
                savegame_br.BaseStream.Position = 0x953;
                byte boots12 = (byte)savegame_fs.ReadByte();
                numericBoots12.Text = (boots12.ToString());

                // 
                savegame_br.BaseStream.Position = 0x954;
                byte boots13 = (byte)savegame_fs.ReadByte();
                numericBoots13.Text = (boots13.ToString());

                // 
                savegame_br.BaseStream.Position = 0x955;
                byte boots14 = (byte)savegame_fs.ReadByte();
                numericBoots14.Text = (boots14.ToString());

                // 
                savegame_br.BaseStream.Position = 0x956;
                byte boots15 = (byte)savegame_fs.ReadByte();
                numericBoots15.Text = (boots15.ToString());

                // 
                savegame_br.BaseStream.Position = 0x957;
                byte boots16 = (byte)savegame_fs.ReadByte();
                numericBoots16.Text = (boots16.ToString());

                // 
                savegame_br.BaseStream.Position = 0x958;
                byte boots17 = (byte)savegame_fs.ReadByte();
                numericBoots17.Text = (boots17.ToString());

                // 
                savegame_br.BaseStream.Position = 0x959;
                byte boots18 = (byte)savegame_fs.ReadByte();
                numericBoots18.Text = (boots18.ToString());

                // 
                savegame_br.BaseStream.Position = 0x95A;
                byte boots19 = (byte)savegame_fs.ReadByte();
                numericBoots19.Text = (boots19.ToString());

                // 
                savegame_br.BaseStream.Position = 0x95B;
                byte boots20 = (byte)savegame_fs.ReadByte();
                numericBoots20.Text = (boots20.ToString());

                // 
                savegame_br.BaseStream.Position = 0x95C;
                byte boots21 = (byte)savegame_fs.ReadByte();
                numericBoots21.Text = (boots21.ToString());

                // 
                savegame_br.BaseStream.Position = 0x95D;
                byte boots22 = (byte)savegame_fs.ReadByte();
                numericBoots22.Text = (boots22.ToString());

                // 
                savegame_br.BaseStream.Position = 0x95E;
                byte boots23 = (byte)savegame_fs.ReadByte();
                numericBoots23.Text = (boots23.ToString());

                // 
                savegame_br.BaseStream.Position = 0x95F;
                byte boots24 = (byte)savegame_fs.ReadByte();
                numericBoots24.Text = (boots24.ToString());

                // 
                savegame_br.BaseStream.Position = 0x960;
                byte boots25 = (byte)savegame_fs.ReadByte();
                numericBoots25.Text = (boots25.ToString());

                // 
                savegame_br.BaseStream.Position = 0x961;
                byte boots26 = (byte)savegame_fs.ReadByte();
                numericBoots26.Text = (boots26.ToString());

                // 
                savegame_br.BaseStream.Position = 0x962;
                byte boots27 = (byte)savegame_fs.ReadByte();
                numericBoots27.Text = (boots27.ToString());

                // 
                savegame_br.BaseStream.Position = 0x963;
                byte boots28 = (byte)savegame_fs.ReadByte();
                numericBoots28.Text = (boots28.ToString());

                // 
                savegame_br.BaseStream.Position = 0x964;
                byte boots29 = (byte)savegame_fs.ReadByte();
                numericBoots29.Text = (boots29.ToString());

                // 
                savegame_br.BaseStream.Position = 0x965;
                byte boots30 = (byte)savegame_fs.ReadByte();
                numericBoots30.Text = (boots30.ToString());

                // 
                savegame_br.BaseStream.Position = 0x966;
                byte boots31 = (byte)savegame_fs.ReadByte();
                numericBoots31.Text = (boots31.ToString());

                // 
                savegame_br.BaseStream.Position = 0x967;
                byte boots32 = (byte)savegame_fs.ReadByte();
                numericBoots32.Text = (boots32.ToString());

                // 
                savegame_br.BaseStream.Position = 0x968;
                byte boots33 = (byte)savegame_fs.ReadByte();
                numericBoots33.Text = (boots33.ToString());

                // 
                savegame_br.BaseStream.Position = 0x969;
                byte boots34 = (byte)savegame_fs.ReadByte();
                numericBoots34.Text = (boots34.ToString());

                // 
                savegame_br.BaseStream.Position = 0x96A;
                byte boots35 = (byte)savegame_fs.ReadByte();
                numericBoots35.Text = (boots35.ToString());

                // 
                savegame_br.BaseStream.Position = 0x96B;
                byte Hammers1 = (byte)savegame_fs.ReadByte();
                numericHammers1.Text = (Hammers1.ToString());

                // 
                savegame_br.BaseStream.Position = 0x96C;
                byte Hammers2 = (byte)savegame_fs.ReadByte();
                numericHammers2.Text = (Hammers2.ToString());

                // 
                savegame_br.BaseStream.Position = 0x96D;
                byte Hammers3 = (byte)savegame_fs.ReadByte();
                numericHammers3.Text = (Hammers3.ToString());

                // 
                savegame_br.BaseStream.Position = 0x96E;
                byte Hammers4 = (byte)savegame_fs.ReadByte();
                numericHammers4.Text = (Hammers4.ToString());

                // 
                savegame_br.BaseStream.Position = 0x96F;
                byte Hammers5 = (byte)savegame_fs.ReadByte();
                numericHammers5.Text = (Hammers5.ToString());

                // 
                savegame_br.BaseStream.Position = 0x970;
                byte Hammers6 = (byte)savegame_fs.ReadByte();
                numericHammers6.Text = (Hammers6.ToString());

                // 
                savegame_br.BaseStream.Position = 0x971;
                byte Hammers7 = (byte)savegame_fs.ReadByte();
                numericHammers7.Text = (Hammers7.ToString());

                // 
                savegame_br.BaseStream.Position = 0x972;
                byte Hammers8 = (byte)savegame_fs.ReadByte();
                numericHammers8.Text = (Hammers8.ToString());

                // 
                savegame_br.BaseStream.Position = 0x973;
                byte Hammers9 = (byte)savegame_fs.ReadByte();
                numericHammers9.Text = (Hammers9.ToString());

                // 
                savegame_br.BaseStream.Position = 0x974;
                byte Hammers10 = (byte)savegame_fs.ReadByte();
                numericHammers10.Text = (Hammers10.ToString());

                // 
                savegame_br.BaseStream.Position = 0x975;
                byte Hammers11 = (byte)savegame_fs.ReadByte();
                numericHammers11.Text = (Hammers11.ToString());

                // 
                savegame_br.BaseStream.Position = 0x976;
                byte Hammers12 = (byte)savegame_fs.ReadByte();
                numericHammers12.Text = (Hammers12.ToString());

                // 
                savegame_br.BaseStream.Position = 0x977;
                byte Hammers13 = (byte)savegame_fs.ReadByte();
                numericHammers13.Text = (Hammers13.ToString());

                // 
                savegame_br.BaseStream.Position = 0x978;
                byte Hammers14 = (byte)savegame_fs.ReadByte();
                numericHammers14.Text = (Hammers14.ToString());

                // 
                savegame_br.BaseStream.Position = 0x979;
                byte Hammers15 = (byte)savegame_fs.ReadByte();
                numericHammers15.Text = (Hammers15.ToString());

                // 
                savegame_br.BaseStream.Position = 0x97A;
                byte Hammers16 = (byte)savegame_fs.ReadByte();
                numericHammers16.Text = (Hammers16.ToString());

                // 
                savegame_br.BaseStream.Position = 0x97B;
                byte Hammers17 = (byte)savegame_fs.ReadByte();
                numericHammers17.Text = (Hammers17.ToString());

                // 
                savegame_br.BaseStream.Position = 0x97C;
                byte Hammers18 = (byte)savegame_fs.ReadByte();
                numericHammers18.Text = (Hammers18.ToString());

                // 
                savegame_br.BaseStream.Position = 0x97D;
                byte Hammers19 = (byte)savegame_fs.ReadByte();
                numericHammers19.Text = (Hammers19.ToString());

                // 
                savegame_br.BaseStream.Position = 0x97E;
                byte Hammers20 = (byte)savegame_fs.ReadByte();
                numericHammers20.Text = (Hammers20.ToString());

                // 
                savegame_br.BaseStream.Position = 0x97F;
                byte Hammers21 = (byte)savegame_fs.ReadByte();
                numericHammers21.Text = (Hammers21.ToString());

                // 
                savegame_br.BaseStream.Position = 0x980;
                byte Hammers22 = (byte)savegame_fs.ReadByte();
                numericHammers22.Text = (Hammers22.ToString());

                // 
                savegame_br.BaseStream.Position = 0x981;
                byte Hammers23 = (byte)savegame_fs.ReadByte();
                numericHammers23.Text = (Hammers23.ToString());

                // 
                savegame_br.BaseStream.Position = 0x982;
                byte Hammers24 = (byte)savegame_fs.ReadByte();
                numericHammers24.Text = (Hammers24.ToString());

                // 
                savegame_br.BaseStream.Position = 0x983;
                byte Hammers25 = (byte)savegame_fs.ReadByte();
                numericHammers25.Text = (Hammers25.ToString());

                // 
                savegame_br.BaseStream.Position = 0x984;
                byte Hammers26 = (byte)savegame_fs.ReadByte();
                numericHammers26.Text = (Hammers26.ToString());

                // 
                savegame_br.BaseStream.Position = 0x985;
                byte Hammers27 = (byte)savegame_fs.ReadByte();
                numericHammers27.Text = (Hammers27.ToString());

                // 
                savegame_br.BaseStream.Position = 0x986;
                byte Hammers28 = (byte)savegame_fs.ReadByte();
                numericHammers28.Text = (Hammers28.ToString());

                // 
                savegame_br.BaseStream.Position = 0x987;
                byte Hammers29 = (byte)savegame_fs.ReadByte();
                numericHammers29.Text = (Hammers29.ToString());

                // 
                savegame_br.BaseStream.Position = 0x988;
                byte Hammers30 = (byte)savegame_fs.ReadByte();
                numericHammers30.Text = (Hammers30.ToString());

                // 
                savegame_br.BaseStream.Position = 0x989;
                byte Hammers31 = (byte)savegame_fs.ReadByte();
                numericHammers31.Text = (Hammers31.ToString());

                // 
                savegame_br.BaseStream.Position = 0x98A;
                byte Hammers32 = (byte)savegame_fs.ReadByte();
                numericHammers32.Text = (Hammers32.ToString());

                // 
                savegame_br.BaseStream.Position = 0x98B;
                byte Hammers33 = (byte)savegame_fs.ReadByte();
                numericHammers33.Text = (Hammers33.ToString());

                // 
                savegame_br.BaseStream.Position = 0x98C;
                byte Hammers34 = (byte)savegame_fs.ReadByte();
                numericHammers34.Text = (Hammers34.ToString());

                // 
                savegame_br.BaseStream.Position = 0x98D;
                byte Hammers35 = (byte)savegame_fs.ReadByte();
                numericHammers35.Text = (Hammers35.ToString());

                // 
                savegame_br.BaseStream.Position = 0x98E;
                byte Wear1 = (byte)savegame_fs.ReadByte();
                numericWear1.Text = (Wear1.ToString());

                // 
                savegame_br.BaseStream.Position = 0x98F;
                byte Wear2 = (byte)savegame_fs.ReadByte();
                numericWear2.Text = (Wear2.ToString());

                // 
                savegame_br.BaseStream.Position = 0x990;
                byte Wear3 = (byte)savegame_fs.ReadByte();
                numericWear3.Text = (Wear3.ToString());

                // 
                savegame_br.BaseStream.Position = 0x991;
                byte Wear4 = (byte)savegame_fs.ReadByte();
                numericWear4.Text = (Wear4.ToString());

                // 
                savegame_br.BaseStream.Position = 0x992;
                byte Wear5 = (byte)savegame_fs.ReadByte();
                numericWear5.Text = (Wear5.ToString());

                // 
                savegame_br.BaseStream.Position = 0x993;
                byte Wear6 = (byte)savegame_fs.ReadByte();
                numericWear6.Text = (Wear6.ToString());

                // 
                savegame_br.BaseStream.Position = 0x994;
                byte Wear7 = (byte)savegame_fs.ReadByte();
                numericWear7.Text = (Wear7.ToString());

                // 
                savegame_br.BaseStream.Position = 0x995;
                byte Wear8 = (byte)savegame_fs.ReadByte();
                numericWear8.Text = (Wear8.ToString());

                // 
                savegame_br.BaseStream.Position = 0x996;
                byte Wear9 = (byte)savegame_fs.ReadByte();
                numericWear9.Text = (Wear9.ToString());

                // 
                savegame_br.BaseStream.Position = 0x997;
                byte Wear10 = (byte)savegame_fs.ReadByte();
                numericWear10.Text = (Wear10.ToString());

                // 
                savegame_br.BaseStream.Position = 0x998;
                byte Wear11 = (byte)savegame_fs.ReadByte();
                numericWear11.Text = (Wear11.ToString());

                // 
                savegame_br.BaseStream.Position = 0x999;
                byte Wear12 = (byte)savegame_fs.ReadByte();
                numericWear12.Text = (Wear12.ToString());

                // 
                savegame_br.BaseStream.Position = 0x99A;
                byte Wear13 = (byte)savegame_fs.ReadByte();
                numericWear13.Text = (Wear13.ToString());

                // 
                savegame_br.BaseStream.Position = 0x99B;
                byte Wear14 = (byte)savegame_fs.ReadByte();
                numericWear14.Text = (Wear14.ToString());

                // 
                savegame_br.BaseStream.Position = 0x99C;
                byte Wear15 = (byte)savegame_fs.ReadByte();
                numericWear15.Text = (Wear15.ToString());

                // 
                savegame_br.BaseStream.Position = 0x99D;
                byte Wear16 = (byte)savegame_fs.ReadByte();
                numericWear16.Text = (Wear16.ToString());

                // 
                savegame_br.BaseStream.Position = 0x99E;
                byte Wear17 = (byte)savegame_fs.ReadByte();
                numericWear17.Text = (Wear17.ToString());

                // 
                savegame_br.BaseStream.Position = 0x99F;
                byte Wear18 = (byte)savegame_fs.ReadByte();
                numericWear18.Text = (Wear18.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9A0;
                byte Wear19 = (byte)savegame_fs.ReadByte();
                numericWear19.Text = (Wear19.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9A1;
                byte Wear20 = (byte)savegame_fs.ReadByte();
                numericWear20.Text = (Wear20.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9A2;
                byte Wear21 = (byte)savegame_fs.ReadByte();
                numericWear21.Text = (Wear21.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9A3;
                byte Wear22 = (byte)savegame_fs.ReadByte();
                numericWear22.Text = (Wear22.ToString());
                
                // 
                savegame_br.BaseStream.Position = 0x9A4;
                byte Wear23 = (byte)savegame_fs.ReadByte();
                numericWear23.Text = (Wear23.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9A5;
                byte Wear24 = (byte)savegame_fs.ReadByte();
                numericWear24.Text = (Wear24.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9A6;
                byte Wear25 = (byte)savegame_fs.ReadByte();
                numericWear25.Text = (Wear25.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9A7;
                byte Wear26 = (byte)savegame_fs.ReadByte();
                numericWear26.Text = (Wear26.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9A8;
                byte Wear27 = (byte)savegame_fs.ReadByte();
                numericWear27.Text = (Wear27.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9A9;
                byte Wear28 = (byte)savegame_fs.ReadByte();
                numericWear28.Text = (Wear28.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9AA;
                byte Wear29 = (byte)savegame_fs.ReadByte();
                numericWear29.Text = (Wear29.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9AB;
                byte Wear30 = (byte)savegame_fs.ReadByte();
                numericWear30.Text = (Wear30.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9AC;
                byte Gloves1 = (byte)savegame_fs.ReadByte();
                numericGloves1.Text = (Gloves1.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9AD;
                byte Gloves2 = (byte)savegame_fs.ReadByte();
                numericGloves2.Text = (Gloves2.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9AE;
                byte Gloves3 = (byte)savegame_fs.ReadByte();
                numericGloves3.Text = (Gloves3.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9AF;
                byte Gloves4 = (byte)savegame_fs.ReadByte();
                numericGloves4.Text = (Gloves4.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9B0;
                byte Gloves5 = (byte)savegame_fs.ReadByte();
                numericGloves5.Text = (Gloves5.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9B1;
                byte Gloves6 = (byte)savegame_fs.ReadByte();
                numericGloves6.Text = (Gloves6.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9B2;
                byte Gloves7 = (byte)savegame_fs.ReadByte();
                numericGloves7.Text = (Gloves7.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9B3;
                byte Gloves8 = (byte)savegame_fs.ReadByte();
                numericGloves8.Text = (Gloves8.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9B4;
                byte Gloves9 = (byte)savegame_fs.ReadByte();
                numericGloves9.Text = (Gloves9.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9B5;
                byte Gloves10 = (byte)savegame_fs.ReadByte();
                numericGloves10.Text = (Gloves10.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9B6;
                byte Gloves11 = (byte)savegame_fs.ReadByte();
                numericGloves11.Text = (Gloves11.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9B7;
                byte Gloves12 = (byte)savegame_fs.ReadByte();
                numericGloves12.Text = (Gloves12.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9B8;
                byte Gloves13 = (byte)savegame_fs.ReadByte();
                numericGloves13.Text = (Gloves13.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9B9;
                byte Gloves14 = (byte)savegame_fs.ReadByte();
                numericGloves14.Text = (Gloves14.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9BA;
                byte Gloves15 = (byte)savegame_fs.ReadByte();
                numericGloves15.Text = (Gloves15.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9BB;
                byte Gloves16 = (byte)savegame_fs.ReadByte();
                numericGloves16.Text = (Gloves16.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9BC;
                byte Gloves17 = (byte)savegame_fs.ReadByte();
                numericGloves17.Text = (Gloves17.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9BD;
                byte Gloves18 = (byte)savegame_fs.ReadByte();
                numericGloves18.Text = (Gloves18.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9BE;
                byte Gloves19 = (byte)savegame_fs.ReadByte();
                numericGloves19.Text = (Gloves19.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9BF;
                byte Gloves20 = (byte)savegame_fs.ReadByte();
                numericGloves20.Text = (Gloves20.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9C0;
                byte Gloves21 = (byte)savegame_fs.ReadByte();
                numericGloves21.Text = (Gloves21.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9C1;
                byte Gloves22 = (byte)savegame_fs.ReadByte();
                numericGloves22.Text = (Gloves22.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9C2;
                byte Gloves23 = (byte)savegame_fs.ReadByte();
                numericGloves23.Text = (Gloves23.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9C3;
                byte Gloves24 = (byte)savegame_fs.ReadByte();
                numericGloves24.Text = (Gloves24.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9C4;
                byte Gloves25 = (byte)savegame_fs.ReadByte();
                numericGloves25.Text = (Gloves25.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9C5;
                byte Gloves26 = (byte)savegame_fs.ReadByte();
                numericGloves26.Text = (Gloves26.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9C6;
                byte Gloves27 = (byte)savegame_fs.ReadByte();
                numericGloves27.Text = (Gloves27.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9C7;
                byte Gloves28 = (byte)savegame_fs.ReadByte();
                numericGloves28.Text = (Gloves28.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9C8;
                byte Gloves29 = (byte)savegame_fs.ReadByte();
                numericGloves29.Text = (Gloves29.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9C9;
                byte Gloves30 = (byte)savegame_fs.ReadByte();
                numericGloves30.Text = (Gloves30.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9CA;
                byte Accessories1 = (byte)savegame_fs.ReadByte();
                numericAccessories1.Text = (Accessories1.ToString());
                
                // 
                savegame_br.BaseStream.Position = 0x9CB;
                byte Accessories2 = (byte)savegame_fs.ReadByte();
                numericAccessories2.Text = (Accessories2.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9CC;
                byte Accessories3 = (byte)savegame_fs.ReadByte();
                numericAccessories3.Text = (Accessories3.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9CD;
                byte Accessories4 = (byte)savegame_fs.ReadByte();
                numericAccessories4.Text = (Accessories4.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9CE;
                byte Accessories5 = (byte)savegame_fs.ReadByte();
                numericAccessories5.Text = (Accessories5.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9CF;
                byte Accessories6 = (byte)savegame_fs.ReadByte();
                numericAccessories6.Text = (Accessories6.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9D0;
                byte Accessories7 = (byte)savegame_fs.ReadByte();
                numericAccessories7.Text = (Accessories7.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9D1;
                byte Accessories8 = (byte)savegame_fs.ReadByte();
                numericAccessories8.Text = (Accessories8.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9D2;
                byte Accessories9 = (byte)savegame_fs.ReadByte();
                numericAccessories9.Text = (Accessories9.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9D3;
                byte Accessories10 = (byte)savegame_fs.ReadByte();
                numericAccessories10.Text = (Accessories10.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9D4;
                byte Accessories11 = (byte)savegame_fs.ReadByte();
                numericAccessories11.Text = (Accessories11.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9D5;
                byte Accessories12 = (byte)savegame_fs.ReadByte();
                numericAccessories12.Text = (Accessories12.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9D6;
                byte Accessories13 = (byte)savegame_fs.ReadByte();
                numericAccessories13.Text = (Accessories13.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9D7;
                byte Accessories14 = (byte)savegame_fs.ReadByte();
                numericAccessories14.Text = (Accessories14.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9D8;
                byte Accessories15 = (byte)savegame_fs.ReadByte();
                numericAccessories15.Text = (Accessories15.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9D9;
                byte Accessories16 = (byte)savegame_fs.ReadByte();
                numericAccessories16.Text = (Accessories16.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9DA;
                byte Accessories17 = (byte)savegame_fs.ReadByte();
                numericAccessories17.Text = (Accessories17.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9DB;
                byte Accessories18 = (byte)savegame_fs.ReadByte();
                numericAccessories18.Text = (Accessories18.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9DC;
                byte Accessories19 = (byte)savegame_fs.ReadByte();
                numericAccessories19.Text = (Accessories19.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9DD;
                byte Accessories20 = (byte)savegame_fs.ReadByte();
                numericAccessories20.Text = (Accessories20.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9DE;
                byte Accessories21 = (byte)savegame_fs.ReadByte();
                numericAccessories21.Text = (Accessories21.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9DF;
                byte Accessories22 = (byte)savegame_fs.ReadByte();
                numericAccessories22.Text = (Accessories22.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9E0;
                byte Accessories23 = (byte)savegame_fs.ReadByte();
                numericAccessories23.Text = (Accessories23.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9E1;
                byte Accessories24 = (byte)savegame_fs.ReadByte();
                numericAccessories24.Text = (Accessories24.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9E2;
                byte Accessories25 = (byte)savegame_fs.ReadByte();
                numericAccessories25.Text = (Accessories25.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9E3;
                byte Accessories26 = (byte)savegame_fs.ReadByte();
                numericAccessories26.Text = (Accessories26.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9E4;
                byte Accessories27 = (byte)savegame_fs.ReadByte();
                numericAccessories27.Text = (Accessories27.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9E5;
                byte Accessories28 = (byte)savegame_fs.ReadByte();
                numericAccessories28.Text = (Accessories28.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9E6;
                byte Accessories29 = (byte)savegame_fs.ReadByte();
                numericAccessories29.Text = (Accessories29.ToString());

                // 
                savegame_br.BaseStream.Position = 0x9E7;
                byte Accessories30 = (byte)savegame_fs.ReadByte();
                numericAccessories30.Text = (Accessories30.ToString());

                savegame_br.Close();
            }

        }

        private void ML4E_set_data()
        {
            FileStream update_save_open = null;
            BinaryWriter update_save_write = null;
            update_save_open = new System.IO.FileStream(savegame, System.IO.FileMode.OpenOrCreate);
            update_save_write = new System.IO.BinaryWriter(update_save_open);

            #region data    
            byte[] rwsd = ML4E_StringToByteArray(byte.Parse(numericRORWAb.Text).ToString("X2"));
            Array.Reverse(rwsd);
            update_save_open.Position = Convert.ToByte("0", 16);
            update_save_write.Write(rwsd);

            byte[] mcurhp = ML4E_StringToByteArray(int.Parse(numericMCurHP.Text).ToString("X4"));
            Array.Reverse(mcurhp);
            update_save_open.Position = Convert.ToInt64("74E", 16);
            update_save_write.Write(mcurhp);

            byte[] mcurbp = ML4E_StringToByteArray(int.Parse(numericMCurBP.Text).ToString("X4"));
            Array.Reverse(mcurbp);
            update_save_open.Position =Convert.ToInt64("750", 16);
            update_save_write.Write(mcurbp);

            byte[] mmaxhp = ML4E_StringToByteArray(int.Parse(numericMMaxHP.Text).ToString("X4"));
            Array.Reverse(mmaxhp);
            update_save_open.Position = Convert.ToInt64("752", 16);
            update_save_write.Write(mmaxhp);

            byte[] mmaxbp = ML4E_StringToByteArray(int.Parse(numericMMaxBP.Text).ToString("X4"));
            Array.Reverse(mmaxbp);
            update_save_open.Position = Convert.ToInt64("754", 16);
            update_save_write.Write(mmaxbp);

            byte[] mpow = ML4E_StringToByteArray(int.Parse(numericMPower.Text).ToString("X4"));
            Array.Reverse(mpow);
            update_save_open.Position = Convert.ToInt64("756", 16);
            update_save_write.Write(mpow);

            byte[] mdef = ML4E_StringToByteArray(int.Parse(numericMDef.Text).ToString("X4"));
            Array.Reverse(mdef);
            update_save_open.Position = Convert.ToInt64("758", 16);
            update_save_write.Write(mdef);

            byte[] mspeed = ML4E_StringToByteArray(int.Parse(numericMSpeed.Text).ToString("X4"));
            Array.Reverse(mspeed);
            update_save_open.Position = Convert.ToInt64("75A", 16);
            update_save_write.Write(mspeed);

            byte[] mstache = ML4E_StringToByteArray(int.Parse(numericMStache.Text).ToString("X4"));
            Array.Reverse(mstache);
            update_save_open.Position = Convert.ToInt64("75C", 16);
            update_save_write.Write(mstache);

            byte[] mbeanhp = ML4E_StringToByteArray(int.Parse(numericMBeanHP.Text).ToString("X4"));
            Array.Reverse(mbeanhp);
            update_save_open.Position = Convert.ToInt64("75E", 16);
            update_save_write.Write(mbeanhp);

            byte[] mlvluphp = ML4E_StringToByteArray(int.Parse(numericMLvlUpHP.Text).ToString("X4"));
            Array.Reverse(mlvluphp);
            update_save_open.Position = Convert.ToInt64("760", 16);
            update_save_write.Write(mlvluphp);

            byte[] mbeanbp = ML4E_StringToByteArray(int.Parse(numericMBeanBP.Text).ToString("X4"));
            Array.Reverse(mbeanbp);
            update_save_open.Position = Convert.ToInt64("762", 16);
            update_save_write.Write(mbeanbp);

            byte[] mlvlupbp = ML4E_StringToByteArray(int.Parse(numericMLvlUpBP.Text).ToString("X4"));
            Array.Reverse(mlvlupbp);
            update_save_open.Position = Convert.ToInt64("764", 16);
            update_save_write.Write(mlvlupbp);

            byte[] mbeanpow = ML4E_StringToByteArray(int.Parse(numericMBeanPow.Text).ToString("X4"));
            Array.Reverse(mbeanpow);
            update_save_open.Position = Convert.ToInt64("766", 16);
            update_save_write.Write(mbeanpow);

            byte[] mlvluppow = ML4E_StringToByteArray(int.Parse(numericMLvlUpPow.Text).ToString("X4"));
            Array.Reverse(mlvluppow);
            update_save_open.Position = Convert.ToInt64("768", 16);
            update_save_write.Write(mlvluppow);

            byte[] mbeandef = ML4E_StringToByteArray(int.Parse(numericMBeanDef.Text).ToString("X4"));
            Array.Reverse(mbeandef);
            update_save_open.Position = Convert.ToInt64("76A", 16);
            update_save_write.Write(mbeandef);

            byte[] mlvlupdef = ML4E_StringToByteArray(int.Parse(numericMLvlUpDef.Text).ToString("X4"));
            Array.Reverse(mlvlupdef);
            update_save_open.Position = Convert.ToInt64("76C", 16);
            update_save_write.Write(mlvlupdef);

            byte[] mbeanspeed = ML4E_StringToByteArray(int.Parse(numericMBeanSpeed.Text).ToString("X4"));
            Array.Reverse(mbeanspeed);
            update_save_open.Position = Convert.ToInt64("76E", 16);
            update_save_write.Write(mbeanspeed);

            byte[] mlvlupspeed = ML4E_StringToByteArray(int.Parse(numericMLvlUpSpeed.Text).ToString("X4"));
            Array.Reverse(mlvlupspeed);
            update_save_open.Position = Convert.ToInt64("770", 16);
            update_save_write.Write(mlvlupspeed);

            byte[] mbeanstache = ML4E_StringToByteArray(int.Parse(numericMBeanStache.Text).ToString("X4"));
            Array.Reverse(mbeanstache);
            update_save_open.Position = Convert.ToInt64("772", 16);
            update_save_write.Write(mbeanstache);

            byte[] mlvlupstache = ML4E_StringToByteArray(int.Parse(numericMLvlUpStache.Text).ToString("X4"));
            Array.Reverse(mlvlupstache);
            update_save_open.Position = Convert.ToInt64("774", 16);
            update_save_write.Write(mlvlupstache);

            byte[] mlvl = ML4E_StringToByteArray(int.Parse(numericMLevel.Text).ToString("X2"));
            Array.Reverse(mlvl);
            update_save_open.Position = Convert.ToInt64("77B", 16);
            update_save_write.Write(mlvl);

            byte[] mexp = ML4E_StringToByteArray(int.Parse(numericMExperience.Text).ToString("X6"));
            Array.Reverse(mexp);
            update_save_open.Position = Convert.ToInt64("778", 16);
            update_save_write.Write(mexp);

            byte[] mrankupbonus1 = ML4E_StringToByteArray(int.Parse(numericRORankupBonusCombo1.Text).ToString("X4"));
            Array.Reverse(mrankupbonus1);
            update_save_open.Position = Convert.ToInt64("78C", 16);
            update_save_write.Write(mrankupbonus1);

            byte[] mrankupbonus2 = ML4E_StringToByteArray(int.Parse(numericRORankupBonusCombo2.Text).ToString("X4"));
            Array.Reverse(mrankupbonus2);
            update_save_open.Position = Convert.ToInt64("78E", 16);
            update_save_write.Write(mrankupbonus2);

            byte[] mrankupbonus3 = ML4E_StringToByteArray(int.Parse(numericRORankupBonusCombo3.Text).ToString("X4"));
            Array.Reverse(mrankupbonus3);
            update_save_open.Position = Convert.ToInt64("790", 16);
            update_save_write.Write(mrankupbonus3);

            byte[] mrankupbonus4 = ML4E_StringToByteArray(int.Parse(numericRORankupBonusCombo4.Text).ToString("X4"));
            Array.Reverse(mrankupbonus4);
            update_save_open.Position = Convert.ToInt64("792", 16);
            update_save_write.Write(mrankupbonus4);

            byte[] mrankupbonus5 = ML4E_StringToByteArray(int.Parse(numericRORankupBonusCombo5.Text).ToString("X4"));
            Array.Reverse(mrankupbonus5);
            update_save_open.Position = Convert.ToInt64("794", 16);
            update_save_write.Write(mrankupbonus5);

            byte[] mgearslot = ML4E_StringToByteArray(int.Parse(numericROMGearSlot.Text).ToString("X2"));
            Array.Reverse(mgearslot);
            update_save_open.Position = Convert.ToInt64("77F", 16);
            update_save_write.Write(mgearslot);

            byte[] lcurhp = ML4E_StringToByteArray(int.Parse(numericLCurHP.Text).ToString("X4"));
            Array.Reverse(lcurhp);
            update_save_open.Position = Convert.ToInt64("836", 16);
            update_save_write.Write(lcurhp);

            byte[] lcurbp = ML4E_StringToByteArray(int.Parse(numericLCurBP.Text).ToString("X4"));
            Array.Reverse(lcurbp);
            update_save_open.Position = Convert.ToInt64("838", 16);
            update_save_write.Write(lcurbp);

            byte[] lmaxhp = ML4E_StringToByteArray(int.Parse(numericLMaxHP.Text).ToString("X4"));
            Array.Reverse(lmaxhp);
            update_save_open.Position = Convert.ToInt64("83A", 16);
            update_save_write.Write(lmaxhp);

            byte[] lmaxbp = ML4E_StringToByteArray(int.Parse(numericLMaxBP.Text).ToString("X4"));
            Array.Reverse(lmaxbp);
            update_save_open.Position = Convert.ToInt64("83C", 16);
            update_save_write.Write(lmaxbp);

            byte[] lpow = ML4E_StringToByteArray(int.Parse(numericLPow.Text).ToString("X4"));
            Array.Reverse(lpow);
            update_save_open.Position = Convert.ToInt64("83E", 16);
            update_save_write.Write(lpow);

            byte[] ldef = ML4E_StringToByteArray(int.Parse(numericLDef.Text).ToString("X4"));
            Array.Reverse(ldef);
            update_save_open.Position = Convert.ToInt64("840", 16);
            update_save_write.Write(ldef);

            byte[] lspeed = ML4E_StringToByteArray(int.Parse(numericLSpeed.Text).ToString("X4"));
            Array.Reverse(lspeed);
            update_save_open.Position = Convert.ToInt64("842", 16);
            update_save_write.Write(lspeed);

            byte[] lstache = ML4E_StringToByteArray(int.Parse(numericLStache.Text).ToString("X4"));
            Array.Reverse(lstache);
            update_save_open.Position = Convert.ToInt64("844", 16);
            update_save_write.Write(lstache);

            byte[] lbeanhp = ML4E_StringToByteArray(int.Parse(numericLBeanHP.Text).ToString("X4"));
            Array.Reverse(lbeanhp);
            update_save_open.Position = Convert.ToInt64("846", 16);
            update_save_write.Write(lbeanhp);

            byte[] llvluphp = ML4E_StringToByteArray(int.Parse(numericLLvlUpHP.Text).ToString("X4"));
            Array.Reverse(llvluphp);
            update_save_open.Position = Convert.ToInt64("848", 16);
            update_save_write.Write(llvluphp);

            byte[] lbeanbp = ML4E_StringToByteArray(int.Parse(numericLBeanBP.Text).ToString("X4"));
            Array.Reverse(lbeanbp);
            update_save_open.Position = Convert.ToInt64("84A", 16);
            update_save_write.Write(lbeanbp);

            byte[] llvlupbp = ML4E_StringToByteArray(int.Parse(numericLLvlUpBP.Text).ToString("X4"));
            Array.Reverse(llvlupbp);
            update_save_open.Position = Convert.ToInt64("84C", 16);
            update_save_write.Write(llvlupbp);

            byte[] lbeanpow = ML4E_StringToByteArray(int.Parse(numericLBeanPow.Text).ToString("X4"));
            Array.Reverse(lbeanpow);
            update_save_open.Position = Convert.ToInt64("84E", 16);
            update_save_write.Write(lbeanpow);

            byte[] llvluppow = ML4E_StringToByteArray(int.Parse(numericLLvlUpPow.Text).ToString("X4"));
            Array.Reverse(llvluppow);
            update_save_open.Position = Convert.ToInt64("850", 16);
            update_save_write.Write(llvluppow);

            byte[] lbeandef = ML4E_StringToByteArray(int.Parse(numericLBeanDef.Text).ToString("X4"));
            Array.Reverse(lbeandef);
            update_save_open.Position = Convert.ToInt64("852", 16);
            update_save_write.Write(lbeandef);

            byte[] llvlupdef = ML4E_StringToByteArray(int.Parse(numericLLvlUpDef.Text).ToString("X4"));
            Array.Reverse(llvlupdef);
            update_save_open.Position = Convert.ToInt64("854", 16);
            update_save_write.Write(llvlupdef);

            byte[] lbeanspeed = ML4E_StringToByteArray(int.Parse(numericLBeanSpeed.Text).ToString("X4"));
            Array.Reverse(lbeanspeed);
            update_save_open.Position = Convert.ToInt64("856", 16);
            update_save_write.Write(lbeanspeed);

            byte[] llvlupspeed = ML4E_StringToByteArray(int.Parse(numericLLvlUpSpeed.Text).ToString("X4"));
            Array.Reverse(llvlupspeed);
            update_save_open.Position = Convert.ToInt64("858", 16);
            update_save_write.Write(llvlupspeed);

            byte[] lbeanstache = ML4E_StringToByteArray(int.Parse(numericLBeanStache.Text).ToString("X4"));
            Array.Reverse(lbeanstache);
            update_save_open.Position = Convert.ToInt64("85A", 16);
            update_save_write.Write(lbeanstache);

            byte[] llvlupstache = ML4E_StringToByteArray(int.Parse(numericLLvlUpStache.Text).ToString("X4"));
            Array.Reverse(llvlupstache);
            update_save_open.Position = Convert.ToInt64("85C", 16);
            update_save_write.Write(llvlupstache);

            byte[] llvl = ML4E_StringToByteArray(int.Parse(numericLLevel.Text).ToString("X2"));
            Array.Reverse(llvl);
            update_save_open.Position = Convert.ToInt64("863", 16);
            update_save_write.Write(llvl);

            byte[] lexp = ML4E_StringToByteArray(int.Parse(numericLExperience.Text).ToString("X6"));
            Array.Reverse(lexp);
            update_save_open.Position = Convert.ToInt64("860", 16);
            update_save_write.Write(lexp);

            byte[] lrankupbonus1 = ML4E_StringToByteArray(int.Parse(numericRORankupBonusCombo6.Text).ToString("X4"));
            Array.Reverse(lrankupbonus1);
            update_save_open.Position = Convert.ToInt64("874", 16);
            update_save_write.Write(lrankupbonus1);

            byte[] lrankupbonus2 = ML4E_StringToByteArray(int.Parse(numericRORankupBonusCombo7.Text).ToString("X4"));
            Array.Reverse(lrankupbonus2);
            update_save_open.Position = Convert.ToInt64("876", 16);
            update_save_write.Write(lrankupbonus2);

            byte[] lrankupbonus3 = ML4E_StringToByteArray(int.Parse(numericRORankupBonusCombo8.Text).ToString("X4"));
            Array.Reverse(lrankupbonus3);
            update_save_open.Position = Convert.ToInt64("878", 16);
            update_save_write.Write(lrankupbonus3);

            byte[] lrankupbonus4 = ML4E_StringToByteArray(int.Parse(numericRORankupBonusCombo9.Text).ToString("X4"));
            Array.Reverse(lrankupbonus4);
            update_save_open.Position = Convert.ToInt64("87A", 16);
            update_save_write.Write(lrankupbonus4);

            byte[] lrankupbonus5 = ML4E_StringToByteArray(int.Parse(numericRORankupBonusCombo10.Text).ToString("X4"));
            Array.Reverse(lrankupbonus5);
            update_save_open.Position = Convert.ToInt64("87C", 16);
            update_save_write.Write(lrankupbonus5);

            byte[] lgearslot = ML4E_StringToByteArray(int.Parse(numericROLGearSlot.Text).ToString("X2"));
            Array.Reverse(lgearslot);
            update_save_open.Position = Convert.ToInt64("867", 16);
            update_save_write.Write(lgearslot);

            byte[] badgeslotcount = ML4E_StringToByteArray(int.Parse(numericUniversalBadgeCount1.Text).ToString("X2"));
            Array.Reverse(badgeslotcount);
            update_save_open.Position = Convert.ToInt64("A09", 16);
            update_save_write.Write(badgeslotcount);

            byte[] nbcunlockflagsd = ML4E_StringToByteArray(byte.Parse(numericRONBCUnlock.Text).ToString("X2"));
            Array.Reverse(nbcunlockflagsd);
            update_save_open.Position = Convert.ToInt64("307", 16);
            update_save_write.Write(nbcunlockflagsd);

            byte[] dwsd = ML4E_StringToByteArray(int.Parse(numericRODWAb.Text).ToString("X4"));
            Array.Reverse(dwsd);
            update_save_open.Position = Convert.ToInt64("1", 8);
            update_save_write.Write(dwsd);

            byte[] havebadges = ML4E_StringToByteArray(int.Parse(numericROHaveBadges.Text).ToString("X2"));
            Array.Reverse(havebadges);
            update_save_open.Position = Convert.ToInt64("1", 8);
            update_save_write.Write(havebadges);

            byte[] money = ML4E_StringToByteArray(int.Parse(box_money.Text).ToString("X8"));
            Array.Reverse(money);
            update_save_open.Position = Convert.ToInt64("91C", 16);
            update_save_write.Write(money);

            byte[] mushroomcount = ML4E_StringToByteArray(int.Parse(numericMushCount.Text).ToString("X2"));
            Array.Reverse(mushroomcount);
            update_save_open.Position = Convert.ToInt64("920", 16);
            update_save_write.Write(mushroomcount);

            byte[] supermushroomcount = ML4E_StringToByteArray(int.Parse(numericSuperMushCount.Text).ToString("X2"));
            Array.Reverse(supermushroomcount);
            update_save_open.Position = Convert.ToInt64("921", 16);
            update_save_write.Write(supermushroomcount);

            byte[] ultramushroomcount = ML4E_StringToByteArray(int.Parse(numericUltraMushCount.Text).ToString("X2"));
            Array.Reverse(ultramushroomcount);
            update_save_open.Position = Convert.ToInt64("922", 16);
            update_save_write.Write(ultramushroomcount);

            byte[] maxmushroomcount = ML4E_StringToByteArray(int.Parse(numericMaxMushCount.Text).ToString("X2"));
            Array.Reverse(maxmushroomcount);
            update_save_open.Position = Convert.ToInt64("923", 16);
            update_save_write.Write(maxmushroomcount);

            byte[] syrupcount = ML4E_StringToByteArray(int.Parse(numericSyrupCount.Text).ToString("X2"));
            Array.Reverse(syrupcount);
            update_save_open.Position = Convert.ToInt64("928", 16);
            update_save_write.Write(syrupcount);

            byte[] supersyrupcount = ML4E_StringToByteArray(int.Parse(numericSupsyrCount.Text).ToString("X2"));
            Array.Reverse(supersyrupcount);
            update_save_open.Position = Convert.ToInt64("929", 16);
            update_save_write.Write(supersyrupcount);

            byte[] ultrasyrupcount = ML4E_StringToByteArray(int.Parse(numericUltraSyrCount.Text).ToString("X2"));
            Array.Reverse(ultrasyrupcount);
            update_save_open.Position = Convert.ToInt64("92A", 16);
            update_save_write.Write(ultrasyrupcount);

            byte[] maxsyrupcount = ML4E_StringToByteArray(int.Parse(numericMaxSyrCount.Text).ToString("X2"));
            Array.Reverse(maxsyrupcount);
            update_save_open.Position = Convert.ToInt64("92B", 16);
            update_save_write.Write(maxsyrupcount);

            byte[] nutcount = ML4E_StringToByteArray(int.Parse(numericNuts.Text).ToString("X2"));
            Array.Reverse(nutcount);
            update_save_open.Position = Convert.ToInt64("924", 16);
            update_save_write.Write(nutcount);

            byte[] supernutcount = ML4E_StringToByteArray(int.Parse(numericSuperNuts.Text).ToString("X2"));
            Array.Reverse(supernutcount);
            update_save_open.Position = Convert.ToInt64("925", 16);
            update_save_write.Write(supernutcount);

            byte[] ultranutcount = ML4E_StringToByteArray(int.Parse(numericUltraNuts.Text).ToString("X2"));
            Array.Reverse(ultranutcount);
            update_save_open.Position = Convert.ToInt64("926", 16);
            update_save_write.Write(ultranutcount);

            byte[] maxnutcount = ML4E_StringToByteArray(int.Parse(numericMaxNuts.Text).ToString("X2"));
            Array.Reverse(maxnutcount);
            update_save_open.Position = Convert.ToInt64("927", 16);
            update_save_write.Write(maxnutcount);

            byte[] candycount = ML4E_StringToByteArray(int.Parse(numericCandies.Text).ToString("X2"));
            Array.Reverse(candycount);
            update_save_open.Position = Convert.ToInt64("92C", 16);
            update_save_write.Write(candycount);

            byte[] supercandycount = ML4E_StringToByteArray(int.Parse(numericSuperCandies.Text).ToString("X2"));
            Array.Reverse(supercandycount);
            update_save_open.Position = Convert.ToInt64("92D", 16);
            update_save_write.Write(supercandycount);

            byte[] ultracandycount = ML4E_StringToByteArray(int.Parse(numericUltraCandies.Text).ToString("X2"));
            Array.Reverse(ultracandycount);
            update_save_open.Position = Convert.ToInt64("92E", 16);
            update_save_write.Write(ultracandycount);

            byte[] maxcandycount = ML4E_StringToByteArray(int.Parse(numericMaxCandies.Text).ToString("X2"));
            Array.Reverse(maxcandycount);
            update_save_open.Position = Convert.ToInt64("92F", 16);
            update_save_write.Write(maxcandycount);

            byte[] oneupcount = ML4E_StringToByteArray(int.Parse(numeric1upMush.Text).ToString("X2"));
            Array.Reverse(oneupcount);
            update_save_open.Position = Convert.ToInt64("930", 16);
            update_save_write.Write(oneupcount);

            byte[] oneupdeluxecount = ML4E_StringToByteArray(int.Parse(numeric1upDeluxe.Text).ToString("X2"));
            Array.Reverse(oneupdeluxecount);
            update_save_open.Position = Convert.ToInt64("931", 16);
            update_save_write.Write(oneupdeluxecount);

            byte[] refreshingherbcount = ML4E_StringToByteArray(int.Parse(numericRefreshingHerbs.Text).ToString("X2"));
            Array.Reverse(refreshingherbcount);
            update_save_open.Position = Convert.ToInt64("932", 16);
            update_save_write.Write(refreshingherbcount);

            byte[] tauntballcount = ML4E_StringToByteArray(int.Parse(numericTauntBall.Text).ToString("X2"));
            Array.Reverse(tauntballcount);
            update_save_open.Position = Convert.ToInt64("939", 16);
            update_save_write.Write(tauntballcount);

            byte[] shockbombcount = ML4E_StringToByteArray(int.Parse(numericShockBomb.Text).ToString("X2"));
            Array.Reverse(shockbombcount);
            update_save_open.Position = Convert.ToInt64("93A", 16);
            update_save_write.Write(shockbombcount);

            byte[] boobiscuitcount = ML4E_StringToByteArray(int.Parse(numericBooBiscuit.Text).ToString("X2"));
            Array.Reverse(boobiscuitcount);
            update_save_open.Position = Convert.ToInt64("93B", 16);
            update_save_write.Write(boobiscuitcount);

            byte[] secretboxcount = ML4E_StringToByteArray(int.Parse(numericSecretBoxes.Text).ToString("X2"));
            Array.Reverse(secretboxcount);
            update_save_open.Position = Convert.ToInt64("93C", 16);
            update_save_write.Write(secretboxcount);

            byte[] heartbeancount = ML4E_StringToByteArray(int.Parse(numericHeartBeans.Text).ToString("X2"));
            Array.Reverse(heartbeancount);
            update_save_open.Position = Convert.ToInt64("933", 16);
            update_save_write.Write(heartbeancount);

            byte[] brosbeancount = ML4E_StringToByteArray(int.Parse(numericBrosBeans.Text).ToString("X2"));
            Array.Reverse(brosbeancount);
            update_save_open.Position = Convert.ToInt64("934", 16);
            update_save_write.Write(brosbeancount);

            byte[] powbeancount = ML4E_StringToByteArray(int.Parse(numericPowerBeans.Text).ToString("X2"));
            Array.Reverse(powbeancount);
            update_save_open.Position = Convert.ToInt64("935", 16);
            update_save_write.Write(powbeancount);

            byte[] defbeancount = ML4E_StringToByteArray(int.Parse(numericDefenseBeans.Text).ToString("X2"));
            Array.Reverse(defbeancount);
            update_save_open.Position = Convert.ToInt64("936", 16);
            update_save_write.Write(defbeancount);

            byte[] speedbeancount = ML4E_StringToByteArray(int.Parse(numericSpeedBeans.Text).ToString("X2"));
            Array.Reverse(speedbeancount);
            update_save_open.Position = Convert.ToInt64("937", 16);
            update_save_write.Write(speedbeancount);

            byte[] higebeancount = ML4E_StringToByteArray(int.Parse(numericStacheBeans.Text).ToString("X2"));
            Array.Reverse(higebeancount);
            update_save_open.Position = Convert.ToInt64("938", 16);
            update_save_write.Write(higebeancount);

            byte[] heartbeandxcount = ML4E_StringToByteArray(int.Parse(numericHeartBeansDX.Text).ToString("X2"));
            Array.Reverse(heartbeandxcount);
            update_save_open.Position = Convert.ToInt64("93D", 16);
            update_save_write.Write(heartbeandxcount);

            byte[] brosbeandxcount = ML4E_StringToByteArray(int.Parse(numericBrosBeansDX.Text).ToString("X2"));
            Array.Reverse(brosbeandxcount);
            update_save_open.Position = Convert.ToInt64("93E", 16);
            update_save_write.Write(brosbeandxcount);

            byte[] powdxbeancount = ML4E_StringToByteArray(int.Parse(numericPowerBeansDX.Text).ToString("X2"));
            Array.Reverse(powdxbeancount);
            update_save_open.Position = Convert.ToInt64("93F", 16);
            update_save_write.Write(powdxbeancount);

            byte[] defdxbeancount = ML4E_StringToByteArray(int.Parse(numericDefenseBeansDX.Text).ToString("X2"));
            Array.Reverse(defdxbeancount);
            update_save_open.Position = Convert.ToInt64("940", 16);
            update_save_write.Write(defdxbeancount);

            byte[] speeddxbeancount = ML4E_StringToByteArray(int.Parse(numericSpeedBeansDX.Text).ToString("X2"));
            Array.Reverse(speeddxbeancount);
            update_save_open.Position = Convert.ToInt64("941", 16);
            update_save_write.Write(speeddxbeancount);

            byte[] higedxbeancount = ML4E_StringToByteArray(int.Parse(numericStacheBeansDX.Text).ToString("X2"));
            Array.Reverse(higedxbeancount);
            update_save_open.Position = Convert.ToInt64("942", 16);
            update_save_write.Write(higedxbeancount);

            byte[] bootscount1 = ML4E_StringToByteArray(int.Parse(numericBoots1.Text).ToString("X2"));
            Array.Reverse(bootscount1);
            update_save_open.Position = Convert.ToInt64("948", 16);
            update_save_write.Write(bootscount1);

            byte[] bootscount2 = ML4E_StringToByteArray(int.Parse(numericBoots2.Text).ToString("X2"));
            Array.Reverse(bootscount2);
            update_save_open.Position = Convert.ToInt64("949", 16);
            update_save_write.Write(bootscount2);

            byte[] bootscount3 = ML4E_StringToByteArray(int.Parse(numericBoots3.Text).ToString("X2"));
            Array.Reverse(bootscount3);
            update_save_open.Position = Convert.ToInt64("94A", 16);
            update_save_write.Write(bootscount3);

            byte[] bootscount4 = ML4E_StringToByteArray(int.Parse(numericBoots4.Text).ToString("X2"));
            Array.Reverse(bootscount4);
            update_save_open.Position = Convert.ToInt64("94B", 16);
            update_save_write.Write(bootscount4);

            byte[] bootscount5 = ML4E_StringToByteArray(int.Parse(numericBoots5.Text).ToString("X2"));
            Array.Reverse(bootscount5);
            update_save_open.Position = Convert.ToInt64("94C", 16);
            update_save_write.Write(bootscount5);

            byte[] bootscount6 = ML4E_StringToByteArray(int.Parse(numericBoots6.Text).ToString("X2"));
            Array.Reverse(bootscount6);
            update_save_open.Position = Convert.ToInt64("94D", 16);
            update_save_write.Write(bootscount6);

            byte[] bootscount7 = ML4E_StringToByteArray(int.Parse(numericBoots7.Text).ToString("X2"));
            Array.Reverse(bootscount7);
            update_save_open.Position = Convert.ToInt64("94E", 16);
            update_save_write.Write(bootscount7);

            byte[] bootscount8 = ML4E_StringToByteArray(int.Parse(numericBoots8.Text).ToString("X2"));
            Array.Reverse(bootscount8);
            update_save_open.Position = Convert.ToInt64("94F", 16);
            update_save_write.Write(bootscount8);

            byte[] bootscount9 = ML4E_StringToByteArray(int.Parse(numericBoots9.Text).ToString("X2"));
            Array.Reverse(bootscount9);
            update_save_open.Position = Convert.ToInt64("950", 16);
            update_save_write.Write(bootscount9);

            byte[] bootscount10 = ML4E_StringToByteArray(int.Parse(numericBoots10.Text).ToString("X2"));
            Array.Reverse(bootscount10);
            update_save_open.Position = Convert.ToInt64("951", 16);
            update_save_write.Write(bootscount10);

            byte[] bootscount11 = ML4E_StringToByteArray(int.Parse(numericBoots11.Text).ToString("X2"));
            Array.Reverse(bootscount11);
            update_save_open.Position = Convert.ToInt64("952", 16);
            update_save_write.Write(bootscount11);

            byte[] bootscount12 = ML4E_StringToByteArray(int.Parse(numericBoots12.Text).ToString("X2"));
            Array.Reverse(bootscount12);
            update_save_open.Position = Convert.ToInt64("953", 16);
            update_save_write.Write(bootscount12);

            byte[] bootscount13 = ML4E_StringToByteArray(int.Parse(numericBoots13.Text).ToString("X2"));
            Array.Reverse(bootscount13);
            update_save_open.Position = Convert.ToInt64("954", 16);
            update_save_write.Write(bootscount13);

            byte[] bootscount14 = ML4E_StringToByteArray(int.Parse(numericBoots14.Text).ToString("X2"));
            Array.Reverse(bootscount14);
            update_save_open.Position = Convert.ToInt64("955", 16);
            update_save_write.Write(bootscount14);

            byte[] bootscount15 = ML4E_StringToByteArray(int.Parse(numericBoots15.Text).ToString("X2"));
            Array.Reverse(bootscount15);
            update_save_open.Position = Convert.ToInt64("956", 16);
            update_save_write.Write(bootscount15);

            byte[] bootscount16 = ML4E_StringToByteArray(int.Parse(numericBoots16.Text).ToString("X2"));
            Array.Reverse(bootscount16);
            update_save_open.Position = Convert.ToInt64("957", 16);
            update_save_write.Write(bootscount16);

            byte[] bootscount17 = ML4E_StringToByteArray(int.Parse(numericBoots17.Text).ToString("X2"));
            Array.Reverse(bootscount17);
            update_save_open.Position = Convert.ToInt64("958", 16);
            update_save_write.Write(bootscount17);

            byte[] bootscount18 = ML4E_StringToByteArray(int.Parse(numericBoots18.Text).ToString("X2"));
            Array.Reverse(bootscount18);
            update_save_open.Position = Convert.ToInt64("959", 16);
            update_save_write.Write(bootscount18);

            byte[] bootscount19 = ML4E_StringToByteArray(int.Parse(numericBoots19.Text).ToString("X2"));
            Array.Reverse(bootscount19);
            update_save_open.Position = Convert.ToInt64("95A", 16);
            update_save_write.Write(bootscount19);

            byte[] bootscount20 = ML4E_StringToByteArray(int.Parse(numericBoots20.Text).ToString("X2"));
            Array.Reverse(bootscount20);
            update_save_open.Position = Convert.ToInt64("95B", 16);
            update_save_write.Write(bootscount20);

            byte[] bootscount21 = ML4E_StringToByteArray(int.Parse(numericBoots21.Text).ToString("X2"));
            Array.Reverse(bootscount21);
            update_save_open.Position = Convert.ToInt64("95C", 16);
            update_save_write.Write(bootscount21);

            byte[] bootscount22 = ML4E_StringToByteArray(int.Parse(numericBoots22.Text).ToString("X2"));
            Array.Reverse(bootscount22);
            update_save_open.Position = Convert.ToInt64("95D", 16);
            update_save_write.Write(bootscount22);

            byte[] bootscount23 = ML4E_StringToByteArray(int.Parse(numericBoots23.Text).ToString("X2"));
            Array.Reverse(bootscount23);
            update_save_open.Position = Convert.ToInt64("95E", 16);
            update_save_write.Write(bootscount23);

            byte[] bootscount24 = ML4E_StringToByteArray(int.Parse(numericBoots24.Text).ToString("X2"));
            Array.Reverse(bootscount24);
            update_save_open.Position = Convert.ToInt64("95F", 16);
            update_save_write.Write(bootscount24);

            byte[] bootscount25 = ML4E_StringToByteArray(int.Parse(numericBoots25.Text).ToString("X2"));
            Array.Reverse(bootscount25);
            update_save_open.Position = Convert.ToInt64("960", 16);
            update_save_write.Write(bootscount25);

            byte[] bootscount26 = ML4E_StringToByteArray(int.Parse(numericBoots26.Text).ToString("X2"));
            Array.Reverse(bootscount26);
            update_save_open.Position = Convert.ToInt64("961", 16);
            update_save_write.Write(bootscount26);

            byte[] bootscount27 = ML4E_StringToByteArray(int.Parse(numericBoots27.Text).ToString("X2"));
            Array.Reverse(bootscount27);
            update_save_open.Position = Convert.ToInt64("962", 16);
            update_save_write.Write(bootscount27);

            byte[] bootscount28 = ML4E_StringToByteArray(int.Parse(numericBoots28.Text).ToString("X2"));
            Array.Reverse(bootscount28);
            update_save_open.Position = Convert.ToInt64("963", 16);
            update_save_write.Write(bootscount28);

            byte[] bootscount29 = ML4E_StringToByteArray(int.Parse(numericBoots29.Text).ToString("X2"));
            Array.Reverse(bootscount29);
            update_save_open.Position = Convert.ToInt64("964", 16);
            update_save_write.Write(bootscount29);

            byte[] bootscount30 = ML4E_StringToByteArray(int.Parse(numericBoots30.Text).ToString("X2"));
            Array.Reverse(bootscount30);
            update_save_open.Position = Convert.ToInt64("965", 16);
            update_save_write.Write(bootscount30);

            byte[] bootscount31 = ML4E_StringToByteArray(int.Parse(numericBoots31.Text).ToString("X2"));
            Array.Reverse(bootscount31);
            update_save_open.Position = Convert.ToInt64("966", 16);
            update_save_write.Write(bootscount31);

            byte[] bootscount32 = ML4E_StringToByteArray(int.Parse(numericBoots32.Text).ToString("X2"));
            Array.Reverse(bootscount32);
            update_save_open.Position = Convert.ToInt64("967", 16);
            update_save_write.Write(bootscount32);

            byte[] bootscount33 = ML4E_StringToByteArray(int.Parse(numericBoots33.Text).ToString("X2"));
            Array.Reverse(bootscount33);
            update_save_open.Position = Convert.ToInt64("968", 16);
            update_save_write.Write(bootscount33);

            byte[] bootscount34 = ML4E_StringToByteArray(int.Parse(numericBoots34.Text).ToString("X2"));
            Array.Reverse(bootscount34);
            update_save_open.Position = Convert.ToInt64("969", 16);
            update_save_write.Write(bootscount34);

            byte[] bootscount35 = ML4E_StringToByteArray(int.Parse(numericBoots35.Text).ToString("X2"));
            Array.Reverse(bootscount35);
            update_save_open.Position = Convert.ToInt64("96A", 16);
            update_save_write.Write(bootscount35);

            byte[] hammerscount1 = ML4E_StringToByteArray(int.Parse(numericHammers1.Text).ToString("X2"));
            Array.Reverse(hammerscount1);
            update_save_open.Position = Convert.ToInt64("96B", 16);
            update_save_write.Write(hammerscount1);

            byte[] hammerscount2 = ML4E_StringToByteArray(int.Parse(numericHammers2.Text).ToString("X2"));
            Array.Reverse(hammerscount2);
            update_save_open.Position = Convert.ToInt64("96C", 16);
            update_save_write.Write(hammerscount2);

            byte[] hammerscount3 = ML4E_StringToByteArray(int.Parse(numericHammers3.Text).ToString("X2"));
            Array.Reverse(hammerscount3);
            update_save_open.Position = Convert.ToInt64("96D", 16);
            update_save_write.Write(hammerscount3);

            byte[] hammerscount4 = ML4E_StringToByteArray(int.Parse(numericHammers4.Text).ToString("X2"));
            Array.Reverse(hammerscount4);
            update_save_open.Position = Convert.ToInt64("96E", 16);
            update_save_write.Write(hammerscount4);

            byte[] hammerscount5 = ML4E_StringToByteArray(int.Parse(numericHammers5.Text).ToString("X2"));
            Array.Reverse(hammerscount5);
            update_save_open.Position = Convert.ToInt64("96F", 16);
            update_save_write.Write(hammerscount5);

            byte[] hammerscount6 = ML4E_StringToByteArray(int.Parse(numericHammers6.Text).ToString("X2"));
            Array.Reverse(hammerscount6);
            update_save_open.Position = Convert.ToInt64("970", 16);
            update_save_write.Write(hammerscount6);

            byte[] hammerscount7 = ML4E_StringToByteArray(int.Parse(numericHammers7.Text).ToString("X2"));
            Array.Reverse(hammerscount7);
            update_save_open.Position = Convert.ToInt64("971", 16);
            update_save_write.Write(hammerscount7);

            byte[] hammerscount8 = ML4E_StringToByteArray(int.Parse(numericHammers8.Text).ToString("X2"));
            Array.Reverse(hammerscount8);
            update_save_open.Position = Convert.ToInt64("972", 16);
            update_save_write.Write(hammerscount8);

            byte[] hammerscount9 = ML4E_StringToByteArray(int.Parse(numericHammers9.Text).ToString("X2"));
            Array.Reverse(hammerscount9);
            update_save_open.Position = Convert.ToInt64("973", 16);
            update_save_write.Write(hammerscount9);

            byte[] hammerscount10 = ML4E_StringToByteArray(int.Parse(numericHammers10.Text).ToString("X2"));
            Array.Reverse(hammerscount10);
            update_save_open.Position = Convert.ToInt64("974", 16);
            update_save_write.Write(hammerscount10);

            byte[] hammerscount11 = ML4E_StringToByteArray(int.Parse(numericHammers11.Text).ToString("X2"));
            Array.Reverse(hammerscount11);
            update_save_open.Position = Convert.ToInt64("975", 16);
            update_save_write.Write(hammerscount11);

            byte[] hammerscount12 = ML4E_StringToByteArray(int.Parse(numericHammers12.Text).ToString("X2"));
            Array.Reverse(hammerscount12);
            update_save_open.Position = Convert.ToInt64("976", 16);
            update_save_write.Write(hammerscount12);

            byte[] hammerscount13 = ML4E_StringToByteArray(int.Parse(numericHammers13.Text).ToString("X2"));
            Array.Reverse(hammerscount13);
            update_save_open.Position = Convert.ToInt64("977", 16);
            update_save_write.Write(hammerscount13);

            byte[] hammerscount14 = ML4E_StringToByteArray(int.Parse(numericHammers14.Text).ToString("X2"));
            Array.Reverse(hammerscount14);
            update_save_open.Position = Convert.ToInt64("978", 16);
            update_save_write.Write(hammerscount14);

            byte[] hammerscount15 = ML4E_StringToByteArray(int.Parse(numericHammers15.Text).ToString("X2"));
            Array.Reverse(hammerscount15);
            update_save_open.Position = Convert.ToInt64("979", 16);
            update_save_write.Write(hammerscount15);

            byte[] hammerscount16 = ML4E_StringToByteArray(int.Parse(numericHammers16.Text).ToString("X2"));
            Array.Reverse(hammerscount16);
            update_save_open.Position = Convert.ToInt64("97A", 16);
            update_save_write.Write(hammerscount16);

            byte[] hammerscount17 = ML4E_StringToByteArray(int.Parse(numericHammers17.Text).ToString("X2"));
            Array.Reverse(hammerscount17);
            update_save_open.Position = Convert.ToInt64("97B", 16);
            update_save_write.Write(hammerscount17);

            byte[] hammerscount18 = ML4E_StringToByteArray(int.Parse(numericHammers18.Text).ToString("X2"));
            Array.Reverse(hammerscount18);
            update_save_open.Position = Convert.ToInt64("97C", 16);
            update_save_write.Write(hammerscount18);

            byte[] hammerscount19 = ML4E_StringToByteArray(int.Parse(numericHammers19.Text).ToString("X2"));
            Array.Reverse(hammerscount19);
            update_save_open.Position = Convert.ToInt64("97D", 16);
            update_save_write.Write(hammerscount19);

            byte[] hammerscount20 = ML4E_StringToByteArray(int.Parse(numericHammers20.Text).ToString("X2"));
            Array.Reverse(hammerscount20);
            update_save_open.Position = Convert.ToInt64("97E", 16);
            update_save_write.Write(hammerscount20);

            byte[] hammerscount21 = ML4E_StringToByteArray(int.Parse(numericHammers21.Text).ToString("X2"));
            Array.Reverse(hammerscount21);
            update_save_open.Position = Convert.ToInt64("97F", 16);
            update_save_write.Write(hammerscount21);

            byte[] hammerscount22 = ML4E_StringToByteArray(int.Parse(numericHammers22.Text).ToString("X2"));
            Array.Reverse(hammerscount22);
            update_save_open.Position = Convert.ToInt64("980", 16);
            update_save_write.Write(hammerscount22);

            byte[] hammerscount23 = ML4E_StringToByteArray(int.Parse(numericHammers23.Text).ToString("X2"));
            Array.Reverse(hammerscount23);
            update_save_open.Position = Convert.ToInt64("981", 16);
            update_save_write.Write(hammerscount23);

            byte[] hammerscount24 = ML4E_StringToByteArray(int.Parse(numericHammers24.Text).ToString("X2"));
            Array.Reverse(hammerscount24);
            update_save_open.Position = Convert.ToInt64("982", 16);
            update_save_write.Write(hammerscount24);

            byte[] hammerscount25 = ML4E_StringToByteArray(int.Parse(numericHammers25.Text).ToString("X2"));
            Array.Reverse(hammerscount25);
            update_save_open.Position = Convert.ToInt64("983", 16);
            update_save_write.Write(hammerscount25);

            byte[] hammerscount26 = ML4E_StringToByteArray(int.Parse(numericHammers26.Text).ToString("X2"));
            Array.Reverse(hammerscount26);
            update_save_open.Position = Convert.ToInt64("984", 16);
            update_save_write.Write(hammerscount26);

            byte[] hammerscount27 = ML4E_StringToByteArray(int.Parse(numericHammers27.Text).ToString("X2"));
            Array.Reverse(hammerscount27);
            update_save_open.Position = Convert.ToInt64("985", 16);
            update_save_write.Write(hammerscount27);

            byte[] hammerscount28 = ML4E_StringToByteArray(int.Parse(numericHammers28.Text).ToString("X2"));
            Array.Reverse(hammerscount28);
            update_save_open.Position = Convert.ToInt64("986", 16);
            update_save_write.Write(hammerscount28);

            byte[] hammerscount29 = ML4E_StringToByteArray(int.Parse(numericHammers29.Text).ToString("X2"));
            Array.Reverse(hammerscount29);
            update_save_open.Position = Convert.ToInt64("987", 16);
            update_save_write.Write(hammerscount29);

            byte[] hammerscount30 = ML4E_StringToByteArray(int.Parse(numericHammers30.Text).ToString("X2"));
            Array.Reverse(hammerscount30);
            update_save_open.Position = Convert.ToInt64("988", 16);
            update_save_write.Write(hammerscount30);

            byte[] hammerscount31 = ML4E_StringToByteArray(int.Parse(numericHammers31.Text).ToString("X2"));
            Array.Reverse(hammerscount31);
            update_save_open.Position = Convert.ToInt64("989", 16);
            update_save_write.Write(hammerscount31);

            byte[] hammerscount32 = ML4E_StringToByteArray(int.Parse(numericHammers32.Text).ToString("X2"));
            Array.Reverse(hammerscount32);
            update_save_open.Position = Convert.ToInt64("98A", 16);
            update_save_write.Write(hammerscount32);

            byte[] hammerscount33 = ML4E_StringToByteArray(int.Parse(numericHammers33.Text).ToString("X2"));
            Array.Reverse(hammerscount33);
            update_save_open.Position = Convert.ToInt64("98B", 16);
            update_save_write.Write(hammerscount33);

            byte[] hammerscount34 = ML4E_StringToByteArray(int.Parse(numericHammers34.Text).ToString("X2"));
            Array.Reverse(hammerscount34);
            update_save_open.Position = Convert.ToInt64("98C", 16);
            update_save_write.Write(hammerscount34);

            byte[] hammerscount35 = ML4E_StringToByteArray(int.Parse(numericHammers35.Text).ToString("X2"));
            Array.Reverse(hammerscount35);
            update_save_open.Position = Convert.ToInt64("98D", 16);
            update_save_write.Write(hammerscount35);

            byte[] wearcount1 = ML4E_StringToByteArray(int.Parse(numericWear1.Text).ToString("X2"));
            Array.Reverse(wearcount1);
            update_save_open.Position = Convert.ToInt64("98E", 16);
            update_save_write.Write(wearcount1);

            byte[] wearcount2 = ML4E_StringToByteArray(int.Parse(numericWear2.Text).ToString("X2"));
            Array.Reverse(wearcount2);
            update_save_open.Position = Convert.ToInt64("98F", 16);
            update_save_write.Write(wearcount2);

            byte[] wearcount3 = ML4E_StringToByteArray(int.Parse(numericWear3.Text).ToString("X2"));
            Array.Reverse(wearcount3);
            update_save_open.Position = Convert.ToInt64("990", 16);
            update_save_write.Write(wearcount3);

            byte[] wearcount4 = ML4E_StringToByteArray(int.Parse(numericWear4.Text).ToString("X2"));
            Array.Reverse(wearcount4);
            update_save_open.Position = Convert.ToInt64("991", 16);
            update_save_write.Write(wearcount4);

            byte[] wearcount5 = ML4E_StringToByteArray(int.Parse(numericWear5.Text).ToString("X2"));
            Array.Reverse(wearcount5);
            update_save_open.Position = Convert.ToInt64("992", 16);
            update_save_write.Write(wearcount5);

            byte[] wearcount6 = ML4E_StringToByteArray(int.Parse(numericWear6.Text).ToString("X2"));
            Array.Reverse(wearcount6);
            update_save_open.Position = Convert.ToInt64("993", 16);
            update_save_write.Write(wearcount6);

            byte[] wearcount7 = ML4E_StringToByteArray(int.Parse(numericWear7.Text).ToString("X2"));
            Array.Reverse(wearcount7);
            update_save_open.Position = Convert.ToInt64("994", 16);
            update_save_write.Write(wearcount7);

            byte[] wearcount8 = ML4E_StringToByteArray(int.Parse(numericWear8.Text).ToString("X2"));
            Array.Reverse(wearcount8);
            update_save_open.Position = Convert.ToInt64("995", 16);
            update_save_write.Write(wearcount8);

            byte[] wearcount9 = ML4E_StringToByteArray(int.Parse(numericWear9.Text).ToString("X2"));
            Array.Reverse(wearcount9);
            update_save_open.Position = Convert.ToInt64("996", 16);
            update_save_write.Write(wearcount9);

            byte[] wearcount10 = ML4E_StringToByteArray(int.Parse(numericWear10.Text).ToString("X2"));
            Array.Reverse(wearcount10);
            update_save_open.Position = Convert.ToInt64("997", 16);
            update_save_write.Write(wearcount10);

            byte[] wearcount11 = ML4E_StringToByteArray(int.Parse(numericWear11.Text).ToString("X2"));
            Array.Reverse(wearcount11);
            update_save_open.Position = Convert.ToInt64("998", 16);
            update_save_write.Write(wearcount11);

            byte[] wearcount12 = ML4E_StringToByteArray(int.Parse(numericWear12.Text).ToString("X2"));
            Array.Reverse(wearcount12);
            update_save_open.Position = Convert.ToInt64("999", 16);
            update_save_write.Write(wearcount12);

            byte[] wearcount13 = ML4E_StringToByteArray(int.Parse(numericWear13.Text).ToString("X2"));
            Array.Reverse(wearcount13);
            update_save_open.Position = Convert.ToInt64("99A", 16);
            update_save_write.Write(wearcount13);

            byte[] wearcount14 = ML4E_StringToByteArray(int.Parse(numericWear14.Text).ToString("X2"));
            Array.Reverse(wearcount14);
            update_save_open.Position = Convert.ToInt64("99B", 16);
            update_save_write.Write(wearcount14);

            byte[] wearcount15 = ML4E_StringToByteArray(int.Parse(numericWear15.Text).ToString("X2"));
            Array.Reverse(wearcount15);
            update_save_open.Position = Convert.ToInt64("99C", 16);
            update_save_write.Write(wearcount15);

            byte[] wearcount16 = ML4E_StringToByteArray(int.Parse(numericWear16.Text).ToString("X2"));
            Array.Reverse(wearcount16);
            update_save_open.Position = Convert.ToInt64("99D", 16);
            update_save_write.Write(wearcount16);

            byte[] wearcount17 = ML4E_StringToByteArray(int.Parse(numericWear17.Text).ToString("X2"));
            Array.Reverse(wearcount17);
            update_save_open.Position = Convert.ToInt64("99E", 16);
            update_save_write.Write(wearcount17);

            byte[] wearcount18 = ML4E_StringToByteArray(int.Parse(numericWear18.Text).ToString("X2"));
            Array.Reverse(wearcount18);
            update_save_open.Position = Convert.ToInt64("99F", 16);
            update_save_write.Write(wearcount18);

            byte[] wearcount19 = ML4E_StringToByteArray(int.Parse(numericWear19.Text).ToString("X2"));
            Array.Reverse(wearcount19);
            update_save_open.Position = Convert.ToInt64("9A0", 16);
            update_save_write.Write(wearcount19);

            byte[] wearcount20 = ML4E_StringToByteArray(int.Parse(numericWear20.Text).ToString("X2"));
            Array.Reverse(wearcount20);
            update_save_open.Position = Convert.ToInt64("9A1", 16);
            update_save_write.Write(wearcount20);

            byte[] wearcount21 = ML4E_StringToByteArray(int.Parse(numericWear21.Text).ToString("X2"));
            Array.Reverse(wearcount21);
            update_save_open.Position = Convert.ToInt64("9A2", 16);
            update_save_write.Write(wearcount21);

            byte[] wearcount22 = ML4E_StringToByteArray(int.Parse(numericWear22.Text).ToString("X2"));
            Array.Reverse(wearcount22);
            update_save_open.Position = Convert.ToInt64("9A3", 16);
            update_save_write.Write(wearcount22);

            byte[] wearcount23 = ML4E_StringToByteArray(int.Parse(numericWear23.Text).ToString("X2"));
            Array.Reverse(wearcount23);
            update_save_open.Position = Convert.ToInt64("9A4", 16);
            update_save_write.Write(wearcount23);

            byte[] wearcount24 = ML4E_StringToByteArray(int.Parse(numericWear24.Text).ToString("X2"));
            Array.Reverse(wearcount24);
            update_save_open.Position = Convert.ToInt64("9A5", 16);
            update_save_write.Write(wearcount24);

            byte[] wearcount25 = ML4E_StringToByteArray(int.Parse(numericWear25.Text).ToString("X2"));
            Array.Reverse(wearcount25);
            update_save_open.Position = Convert.ToInt64("9A6", 16);
            update_save_write.Write(wearcount25);

            byte[] wearcount26 = ML4E_StringToByteArray(int.Parse(numericWear26.Text).ToString("X2"));
            Array.Reverse(wearcount26);
            update_save_open.Position = Convert.ToInt64("9A7", 16);
            update_save_write.Write(wearcount26);

            byte[] wearcount27 = ML4E_StringToByteArray(int.Parse(numericWear27.Text).ToString("X2"));
            Array.Reverse(wearcount27);
            update_save_open.Position = Convert.ToInt64("9A8", 16);
            update_save_write.Write(wearcount27);

            byte[] wearcount28 = ML4E_StringToByteArray(int.Parse(numericWear28.Text).ToString("X2"));
            Array.Reverse(wearcount28);
            update_save_open.Position = Convert.ToInt64("9A9", 16);
            update_save_write.Write(wearcount28);

            byte[] wearcount29 = ML4E_StringToByteArray(int.Parse(numericWear29.Text).ToString("X2"));
            Array.Reverse(wearcount29);
            update_save_open.Position = Convert.ToInt64("9AA", 16);
            update_save_write.Write(wearcount29);

            byte[] wearcount30 = ML4E_StringToByteArray(int.Parse(numericWear30.Text).ToString("X2"));
            Array.Reverse(wearcount30);
            update_save_open.Position = Convert.ToInt64("9AB", 16);
            update_save_write.Write(wearcount30);

            byte[] glovescount1 = ML4E_StringToByteArray(int.Parse(numericGloves1.Text).ToString("X2"));
            Array.Reverse(glovescount1);
            update_save_open.Position = Convert.ToInt64("9AC", 16);
            update_save_write.Write(glovescount1);

            byte[] glovescount2 = ML4E_StringToByteArray(int.Parse(numericGloves2.Text).ToString("X2"));
            Array.Reverse(glovescount2);
            update_save_open.Position = Convert.ToInt64("9AD", 16);
            update_save_write.Write(glovescount2);

            byte[] glovescount3 = ML4E_StringToByteArray(int.Parse(numericGloves3.Text).ToString("X2"));
            Array.Reverse(glovescount3);
            update_save_open.Position = Convert.ToInt64("9AE", 16);
            update_save_write.Write(glovescount3);

            byte[] glovescount4 = ML4E_StringToByteArray(int.Parse(numericGloves4.Text).ToString("X2"));
            Array.Reverse(glovescount4);
            update_save_open.Position = Convert.ToInt64("9AF", 16);
            update_save_write.Write(glovescount4);

            byte[] glovescount5 = ML4E_StringToByteArray(int.Parse(numericGloves5.Text).ToString("X2"));
            Array.Reverse(glovescount5);
            update_save_open.Position = Convert.ToInt64("9B0", 16);
            update_save_write.Write(glovescount5);

            byte[] glovescount6 = ML4E_StringToByteArray(int.Parse(numericGloves6.Text).ToString("X2"));
            Array.Reverse(glovescount6);
            update_save_open.Position = Convert.ToInt64("9B1", 16);
            update_save_write.Write(glovescount6);

            byte[] glovescount7 = ML4E_StringToByteArray(int.Parse(numericGloves7.Text).ToString("X2"));
            Array.Reverse(glovescount7);
            update_save_open.Position = Convert.ToInt64("9B2", 16);
            update_save_write.Write(glovescount7);

            byte[] glovescount8 = ML4E_StringToByteArray(int.Parse(numericGloves8.Text).ToString("X2"));
            Array.Reverse(glovescount8);
            update_save_open.Position = Convert.ToInt64("9B3", 16);
            update_save_write.Write(glovescount8);

            byte[] glovescount9 = ML4E_StringToByteArray(int.Parse(numericGloves9.Text).ToString("X2"));
            Array.Reverse(glovescount9);
            update_save_open.Position = Convert.ToInt64("9B4", 16);
            update_save_write.Write(glovescount9);

            byte[] glovescount10 = ML4E_StringToByteArray(int.Parse(numericGloves10.Text).ToString("X2"));
            Array.Reverse(glovescount10);
            update_save_open.Position = Convert.ToInt64("9B5", 16);
            update_save_write.Write(glovescount10);

            byte[] glovescount11 = ML4E_StringToByteArray(int.Parse(numericGloves11.Text).ToString("X2"));
            Array.Reverse(glovescount11);
            update_save_open.Position = Convert.ToInt64("9B6", 16);
            update_save_write.Write(glovescount11);

            byte[] glovescount12 = ML4E_StringToByteArray(int.Parse(numericGloves12.Text).ToString("X2"));
            Array.Reverse(glovescount12);
            update_save_open.Position = Convert.ToInt64("9B7", 16);
            update_save_write.Write(glovescount12);

            byte[] glovescount13 = ML4E_StringToByteArray(int.Parse(numericGloves13.Text).ToString("X2"));
            Array.Reverse(glovescount13);
            update_save_open.Position = Convert.ToInt64("9B8", 16);
            update_save_write.Write(glovescount13);

            byte[] glovescount14 = ML4E_StringToByteArray(int.Parse(numericGloves14.Text).ToString("X2"));
            Array.Reverse(glovescount14);
            update_save_open.Position = Convert.ToInt64("9B9", 16);
            update_save_write.Write(glovescount14);

            byte[] glovescount15 = ML4E_StringToByteArray(int.Parse(numericGloves15.Text).ToString("X2"));
            Array.Reverse(glovescount15);
            update_save_open.Position = Convert.ToInt64("9BA", 16);
            update_save_write.Write(glovescount15);

            byte[] glovescount16 = ML4E_StringToByteArray(int.Parse(numericGloves16.Text).ToString("X2"));
            Array.Reverse(glovescount16);
            update_save_open.Position = Convert.ToInt64("9BB", 16);
            update_save_write.Write(glovescount16);

            byte[] glovescount17 = ML4E_StringToByteArray(int.Parse(numericGloves17.Text).ToString("X2"));
            Array.Reverse(glovescount17);
            update_save_open.Position = Convert.ToInt64("9BC", 16);
            update_save_write.Write(glovescount17);

            byte[] glovescount18 = ML4E_StringToByteArray(int.Parse(numericGloves18.Text).ToString("X2"));
            Array.Reverse(glovescount18);
            update_save_open.Position = Convert.ToInt64("9BD", 16);
            update_save_write.Write(glovescount18);

            byte[] glovescount19 = ML4E_StringToByteArray(int.Parse(numericGloves19.Text).ToString("X2"));
            Array.Reverse(glovescount19);
            update_save_open.Position = Convert.ToInt64("9BE", 16);
            update_save_write.Write(glovescount19);

            byte[] glovescount20 = ML4E_StringToByteArray(int.Parse(numericGloves20.Text).ToString("X2"));
            Array.Reverse(glovescount20);
            update_save_open.Position = Convert.ToInt64("9BF", 16);
            update_save_write.Write(glovescount20);

            byte[] glovescount21 = ML4E_StringToByteArray(int.Parse(numericGloves21.Text).ToString("X2"));
            Array.Reverse(glovescount21);
            update_save_open.Position = Convert.ToInt64("9C0", 16);
            update_save_write.Write(glovescount21);

            byte[] glovescount22 = ML4E_StringToByteArray(int.Parse(numericGloves22.Text).ToString("X2"));
            Array.Reverse(glovescount22);
            update_save_open.Position = Convert.ToInt64("9C1", 16);
            update_save_write.Write(glovescount22);

            byte[] glovescount23 = ML4E_StringToByteArray(int.Parse(numericGloves23.Text).ToString("X2"));
            Array.Reverse(glovescount23);
            update_save_open.Position = Convert.ToInt64("9C2", 16);
            update_save_write.Write(glovescount23);

            byte[] glovescount24 = ML4E_StringToByteArray(int.Parse(numericGloves24.Text).ToString("X2"));
            Array.Reverse(glovescount24);
            update_save_open.Position = Convert.ToInt64("9C3", 16);
            update_save_write.Write(glovescount24);

            byte[] glovescount25 = ML4E_StringToByteArray(int.Parse(numericGloves25.Text).ToString("X2"));
            Array.Reverse(glovescount25);
            update_save_open.Position = Convert.ToInt64("9C4", 16);
            update_save_write.Write(glovescount25);

            byte[] glovescount26 = ML4E_StringToByteArray(int.Parse(numericGloves26.Text).ToString("X2"));
            Array.Reverse(glovescount26);
            update_save_open.Position = Convert.ToInt64("9C5", 16);
            update_save_write.Write(glovescount26);

            byte[] glovescount27 = ML4E_StringToByteArray(int.Parse(numericGloves27.Text).ToString("X2"));
            Array.Reverse(glovescount27);
            update_save_open.Position = Convert.ToInt64("9C6", 16);
            update_save_write.Write(glovescount27);

            byte[] glovescount28 = ML4E_StringToByteArray(int.Parse(numericGloves28.Text).ToString("X2"));
            Array.Reverse(glovescount28);
            update_save_open.Position = Convert.ToInt64("9C7", 16);
            update_save_write.Write(glovescount28);

            byte[] glovescount29 = ML4E_StringToByteArray(int.Parse(numericGloves29.Text).ToString("X2"));
            Array.Reverse(glovescount29);
            update_save_open.Position = Convert.ToInt64("9C8", 16);
            update_save_write.Write(glovescount29);

            byte[] glovescount30 = ML4E_StringToByteArray(int.Parse(numericGloves30.Text).ToString("X2"));
            Array.Reverse(glovescount30);
            update_save_open.Position = Convert.ToInt64("9C9", 16);
            update_save_write.Write(glovescount30);

            byte[] accessoriescount1 = ML4E_StringToByteArray(int.Parse(numericAccessories1.Text).ToString("X2"));
            Array.Reverse(accessoriescount1);
            update_save_open.Position = Convert.ToInt64("9CA", 16);
            update_save_write.Write(accessoriescount1);

            byte[] accessoriescount2 = ML4E_StringToByteArray(int.Parse(numericAccessories2.Text).ToString("X2"));
            Array.Reverse(accessoriescount2);
            update_save_open.Position = Convert.ToInt64("9CB", 16);
            update_save_write.Write(accessoriescount2);

            byte[] accessoriescount3 = ML4E_StringToByteArray(int.Parse(numericAccessories3.Text).ToString("X2"));
            Array.Reverse(accessoriescount3);
            update_save_open.Position = Convert.ToInt64("9CC", 16);
            update_save_write.Write(accessoriescount3);

            byte[] accessoriescount4 = ML4E_StringToByteArray(int.Parse(numericAccessories4.Text).ToString("X2"));
            Array.Reverse(accessoriescount4);
            update_save_open.Position = Convert.ToInt64("9CD", 16);
            update_save_write.Write(accessoriescount4);

            byte[] accessoriescount5 = ML4E_StringToByteArray(int.Parse(numericAccessories5.Text).ToString("X2"));
            Array.Reverse(accessoriescount5);
            update_save_open.Position = Convert.ToInt64("9CE", 16);
            update_save_write.Write(accessoriescount5);

            byte[] accessoriescount6 = ML4E_StringToByteArray(int.Parse(numericAccessories6.Text).ToString("X2"));
            Array.Reverse(accessoriescount6);
            update_save_open.Position = Convert.ToInt64("9CF", 16);
            update_save_write.Write(accessoriescount6);

            byte[] accessoriescount7 = ML4E_StringToByteArray(int.Parse(numericAccessories7.Text).ToString("X2"));
            Array.Reverse(accessoriescount7);
            update_save_open.Position = Convert.ToInt64("9D0", 16);
            update_save_write.Write(accessoriescount7);

            byte[] accessoriescount8 = ML4E_StringToByteArray(int.Parse(numericAccessories8.Text).ToString("X2"));
            Array.Reverse(accessoriescount8);
            update_save_open.Position = Convert.ToInt64("9D1", 16);
            update_save_write.Write(accessoriescount8);

            byte[] accessoriescount9 = ML4E_StringToByteArray(int.Parse(numericAccessories9.Text).ToString("X2"));
            Array.Reverse(accessoriescount9);
            update_save_open.Position = Convert.ToInt64("9D2", 16);
            update_save_write.Write(accessoriescount9);

            byte[] accessoriescount10 = ML4E_StringToByteArray(int.Parse(numericAccessories10.Text).ToString("X2"));
            Array.Reverse(accessoriescount10);
            update_save_open.Position = Convert.ToInt64("9D3", 16);
            update_save_write.Write(accessoriescount10);

            byte[] accessoriescount11 = ML4E_StringToByteArray(int.Parse(numericAccessories11.Text).ToString("X2"));
            Array.Reverse(accessoriescount11);
            update_save_open.Position = Convert.ToInt64("9D4", 16);
            update_save_write.Write(accessoriescount11);

            byte[] accessoriescount12 = ML4E_StringToByteArray(int.Parse(numericAccessories12.Text).ToString("X2"));
            Array.Reverse(accessoriescount12);
            update_save_open.Position = Convert.ToInt64("9D5", 16);
            update_save_write.Write(accessoriescount12);

            byte[] accessoriescount13 = ML4E_StringToByteArray(int.Parse(numericAccessories13.Text).ToString("X2"));
            Array.Reverse(accessoriescount13);
            update_save_open.Position = Convert.ToInt64("9D6", 16);
            update_save_write.Write(accessoriescount13);

            byte[] accessoriescount14 = ML4E_StringToByteArray(int.Parse(numericAccessories14.Text).ToString("X2"));
            Array.Reverse(accessoriescount14);
            update_save_open.Position = Convert.ToInt64("9D7", 16);
            update_save_write.Write(accessoriescount14);

            byte[] accessoriescount15 = ML4E_StringToByteArray(int.Parse(numericAccessories15.Text).ToString("X2"));
            Array.Reverse(accessoriescount15);
            update_save_open.Position = Convert.ToInt64("9D8", 16);
            update_save_write.Write(accessoriescount15);

            byte[] accessoriescount16 = ML4E_StringToByteArray(int.Parse(numericAccessories16.Text).ToString("X2"));
            Array.Reverse(accessoriescount16);
            update_save_open.Position = Convert.ToInt64("9D9", 16);
            update_save_write.Write(accessoriescount16);

            byte[] accessoriescount17 = ML4E_StringToByteArray(int.Parse(numericAccessories17.Text).ToString("X2"));
            Array.Reverse(accessoriescount17);
            update_save_open.Position = Convert.ToInt64("9DA", 16);
            update_save_write.Write(accessoriescount17);

            byte[] accessoriescount18 = ML4E_StringToByteArray(int.Parse(numericAccessories18.Text).ToString("X2"));
            Array.Reverse(accessoriescount18);
            update_save_open.Position = Convert.ToInt64("9DB", 16);
            update_save_write.Write(accessoriescount18);

            byte[] accessoriescount19 = ML4E_StringToByteArray(int.Parse(numericAccessories19.Text).ToString("X2"));
            Array.Reverse(accessoriescount19);
            update_save_open.Position = Convert.ToInt64("9DC", 16);
            update_save_write.Write(accessoriescount19);

            byte[] accessoriescount20 = ML4E_StringToByteArray(int.Parse(numericAccessories20.Text).ToString("X2"));
            Array.Reverse(accessoriescount20);
            update_save_open.Position = Convert.ToInt64("9DD", 16);
            update_save_write.Write(accessoriescount20);

            byte[] accessoriescount21 = ML4E_StringToByteArray(int.Parse(numericAccessories21.Text).ToString("X2"));
            Array.Reverse(accessoriescount21);
            update_save_open.Position = Convert.ToInt64("9DE", 16);
            update_save_write.Write(accessoriescount21);

            byte[] accessoriescount22 = ML4E_StringToByteArray(int.Parse(numericAccessories22.Text).ToString("X2"));
            Array.Reverse(accessoriescount22);
            update_save_open.Position = Convert.ToInt64("9DF", 16);
            update_save_write.Write(accessoriescount22);

            byte[] accessoriescount23 = ML4E_StringToByteArray(int.Parse(numericAccessories23.Text).ToString("X2"));
            Array.Reverse(accessoriescount23);
            update_save_open.Position = Convert.ToInt64("9E0", 16);
            update_save_write.Write(accessoriescount23);

            byte[] accessoriescount24 = ML4E_StringToByteArray(int.Parse(numericAccessories24.Text).ToString("X2"));
            Array.Reverse(accessoriescount24);
            update_save_open.Position = Convert.ToInt64("9E1", 16);
            update_save_write.Write(accessoriescount24);

            byte[] accessoriescount25 = ML4E_StringToByteArray(int.Parse(numericAccessories25.Text).ToString("X2"));
            Array.Reverse(accessoriescount25);
            update_save_open.Position = Convert.ToInt64("9E2", 16);
            update_save_write.Write(accessoriescount25);

            byte[] accessoriescount26 = ML4E_StringToByteArray(int.Parse(numericAccessories26.Text).ToString("X2"));
            Array.Reverse(accessoriescount26);
            update_save_open.Position = Convert.ToInt64("9E3", 16);
            update_save_write.Write(accessoriescount26);

            byte[] accessoriescount27 = ML4E_StringToByteArray(int.Parse(numericAccessories27.Text).ToString("X2"));
            Array.Reverse(accessoriescount27);
            update_save_open.Position = Convert.ToInt64("9E4", 16);
            update_save_write.Write(accessoriescount27);

            byte[] accessoriescount28 = ML4E_StringToByteArray(int.Parse(numericAccessories28.Text).ToString("X2"));
            Array.Reverse(accessoriescount28);
            update_save_open.Position = Convert.ToInt64("9E5", 16);
            update_save_write.Write(accessoriescount28);

            byte[] accessoriescount29 = ML4E_StringToByteArray(int.Parse(numericAccessories29.Text).ToString("X2"));
            Array.Reverse(accessoriescount29);
            update_save_open.Position = Convert.ToInt64("9E6", 16);
            update_save_write.Write(accessoriescount29);

            byte[] accessoriescount30 = ML4E_StringToByteArray(int.Parse(numericAccessories30.Text).ToString("X2"));
            Array.Reverse(accessoriescount30);
            update_save_open.Position = Convert.ToInt64("9E7", 16);
            update_save_write.Write(accessoriescount30);

            #endregion

            update_save_open.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ML4E_get_openfile();
            if (string.IsNullOrEmpty(savegame))
            {
                MessageBox.Show("no savegame selected");
            }
            else
            {
                ML4E_get_data();
                FileStream savegame_fs = new FileStream(savegame, FileMode.Open);
                BinaryReader savegame_br = new BinaryReader(savegame_fs);
                save.Enabled = true;
                box_money.ReadOnly = false;
                buttonMaxItems.Enabled = true;
                buttonXAccessories.Enabled = true;
                buttonXBoots.Enabled = true;
                buttonXGloves.Enabled = true;
                buttonXHammers.Enabled = true;
                buttonXWear.Enabled = true;
                tabControl1.Enabled = true;
                tabControl1.Visible = true;
                numericUniversalBadgeCount2.Value = numericUniversalBadgeCount1.Value;  
                numericMExperience.Value = ((65536 * numericMExperienceHidden2.Value) + numericMExperienceHidden1.Value); // Adds the third bit of 0x77A to the two-byte address of 0x778
                numericLExperience.Value = ((65536 * numericLExperienceHidden2.Value) + numericLExperienceHidden1.Value);
                long length = savegame_fs.Length;
                savegame_br.BaseStream.Position = 0x77F;
                byte[] rank = savegame_br.ReadBytes(4);
                int rank1 = BitConverter.ToInt32(rank, 0);
                savegame_br.Close();

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ML4E_set_data();
            MessageBox.Show("Data saved");
        }

        private void buttonMaxItems_Click(object sender, EventArgs e)
        {
            numericMushCount.Text = numericXEverythingItem.Text;
            numericSuperMushCount.Text = numericXEverythingItem.Text;
            numericUltraMushCount.Text = numericXEverythingItem.Text;
            numericMaxMushCount.Text = numericXEverythingItem.Text;
            numericSyrupCount.Text = numericXEverythingItem.Text;
            numericSupsyrCount.Text = numericXEverythingItem.Text;
            numericUltraSyrCount.Text = numericXEverythingItem.Text;
            numericMaxSyrCount.Text = numericXEverythingItem.Text;
            numericNuts.Text = numericXEverythingItem.Text;
            numericSuperNuts.Text = numericXEverythingItem.Text;
            numericUltraNuts.Text = numericXEverythingItem.Text;
            numericMaxNuts.Text = numericXEverythingItem.Text;
            numericCandies.Text = numericXEverythingItem.Text;
            numericSuperCandies.Text = numericXEverythingItem.Text;
            numericUltraCandies.Text = numericXEverythingItem.Text;
            numericMaxCandies.Text = numericXEverythingItem.Text;
            numeric1upMush.Text = numericXEverythingItem.Text;
            numeric1upDeluxe.Text = numericXEverythingItem.Text;
            numericBooBiscuit.Text = numericXEverythingItem.Text;
            numericSecretBoxes.Text = numericXEverythingItem.Text;
            numericShockBomb.Text = numericXEverythingItem.Text;
            numericTauntBall.Text = numericXEverythingItem.Text;
            numericHeartBeans.Text = numericXEverythingItem.Text;
            numericHeartBeansDX.Text = numericXEverythingItem.Text;
            numericBrosBeans.Text = numericXEverythingItem.Text;
            numericBrosBeansDX.Text = numericXEverythingItem.Text;
            numericPowerBeans.Text = numericXEverythingItem.Text;
            numericPowerBeansDX.Text = numericXEverythingItem.Text;
            numericDefenseBeans.Text = numericXEverythingItem.Text;
            numericDefenseBeansDX.Text = numericXEverythingItem.Text;
            numericSpeedBeans.Text = numericXEverythingItem.Text;
            numericSpeedBeansDX.Text = numericXEverythingItem.Text;
            numericStacheBeans.Text = numericXEverythingItem.Text;
            numericStacheBeansDX.Text = numericXEverythingItem.Text;
            numericRefreshingHerbs.Text = numericXEverythingItem.Text;
        }

        private void buttonXBoots_Click(object sender, EventArgs e)
        {
            numericBoots1.Text = numericXBoots.Text;
            numericBoots2.Text = numericXBoots.Text;
            numericBoots3.Text = numericXBoots.Text;
            numericBoots4.Text = numericXBoots.Text;
            numericBoots5.Text = numericXBoots.Text;
            numericBoots6.Text = numericXBoots.Text;
            numericBoots7.Text = numericXBoots.Text;
            numericBoots8.Text = numericXBoots.Text;
            numericBoots9.Text = numericXBoots.Text;
            numericBoots10.Text = numericXBoots.Text;
            numericBoots11.Text = numericXBoots.Text;
            numericBoots12.Text = numericXBoots.Text;
            numericBoots13.Text = numericXBoots.Text;
            numericBoots14.Text = numericXBoots.Text;
            numericBoots15.Text = numericXBoots.Text;
            numericBoots16.Text = numericXBoots.Text;
            numericBoots17.Text = numericXBoots.Text;
            numericBoots18.Text = numericXBoots.Text;
            numericBoots19.Text = numericXBoots.Text;
            numericBoots20.Text = numericXBoots.Text;
            numericBoots21.Text = numericXBoots.Text;
            numericBoots22.Text = numericXBoots.Text;
            numericBoots23.Text = numericXBoots.Text;
            numericBoots24.Text = numericXBoots.Text;
            numericBoots25.Text = numericXBoots.Text;
            numericBoots26.Text = numericXBoots.Text;
            numericBoots27.Text = numericXBoots.Text;
            numericBoots28.Text = numericXBoots.Text;
            numericBoots29.Text = numericXBoots.Text;
            numericBoots30.Text = numericXBoots.Text;
            numericBoots31.Text = numericXBoots.Text;
            numericBoots32.Text = numericXBoots.Text;
            numericBoots33.Text = numericXBoots.Text;
            numericBoots34.Text = numericXBoots.Text;
            numericBoots35.Text = numericXBoots.Text;

        }

        private void buttonXHammers_Click(object sender, EventArgs e)
        {
            numericHammers1.Text = numericXHammers.Text;
            numericHammers2.Text = numericXHammers.Text;
            numericHammers3.Text = numericXHammers.Text;
            numericHammers4.Text = numericXHammers.Text;
            numericHammers5.Text = numericXHammers.Text;
            numericHammers6.Text = numericXHammers.Text;
            numericHammers7.Text = numericXHammers.Text;
            numericHammers8.Text = numericXHammers.Text;
            numericHammers9.Text = numericXHammers.Text;
            numericHammers10.Text = numericXHammers.Text;
            numericHammers11.Text = numericXHammers.Text;
            numericHammers12.Text = numericXHammers.Text;
            numericHammers13.Text = numericXHammers.Text;
            numericHammers14.Text = numericXHammers.Text;
            numericHammers15.Text = numericXHammers.Text;
            numericHammers16.Text = numericXHammers.Text;
            numericHammers17.Text = numericXHammers.Text;
            numericHammers18.Text = numericXHammers.Text;
            numericHammers19.Text = numericXHammers.Text;
            numericHammers20.Text = numericXHammers.Text;
            numericHammers21.Text = numericXHammers.Text;
            numericHammers22.Text = numericXHammers.Text;
            numericHammers23.Text = numericXHammers.Text;
            numericHammers24.Text = numericXHammers.Text;
            numericHammers25.Text = numericXHammers.Text;
            numericHammers26.Text = numericXHammers.Text;
            numericHammers27.Text = numericXHammers.Text;
            numericHammers28.Text = numericXHammers.Text;
            numericHammers29.Text = numericXHammers.Text;
            numericHammers30.Text = numericXHammers.Text;
            numericHammers31.Text = numericXHammers.Text;
            numericHammers32.Text = numericXHammers.Text;
            numericHammers33.Text = numericXHammers.Text;
            numericHammers34.Text = numericXHammers.Text;
            numericHammers35.Text = numericXHammers.Text;
        }

        private void buttonXWear_Click(object sender, EventArgs e)
        {
            numericWear1.Text = numericXWear.Text;
            numericWear2.Text = numericXWear.Text;
            numericWear3.Text = numericXWear.Text;
            numericWear4.Text = numericXWear.Text;
            numericWear5.Text = numericXWear.Text;
            numericWear6.Text = numericXWear.Text;
            numericWear7.Text = numericXWear.Text;
            numericWear8.Text = numericXWear.Text;
            numericWear9.Text = numericXWear.Text;
            numericWear10.Text = numericXWear.Text;
            numericWear11.Text = numericXWear.Text;
            numericWear12.Text = numericXWear.Text;
            numericWear13.Text = numericXWear.Text;
            numericWear14.Text = numericXWear.Text;
            numericWear15.Text = numericXWear.Text;
            numericWear16.Text = numericXWear.Text;
            numericWear17.Text = numericXWear.Text;
            numericWear18.Text = numericXWear.Text;
            numericWear19.Text = numericXWear.Text;
            numericWear20.Text = numericXWear.Text;
            numericWear21.Text = numericXWear.Text;
            numericWear22.Text = numericXWear.Text;
            numericWear23.Text = numericXWear.Text;
            numericWear24.Text = numericXWear.Text;
            numericWear25.Text = numericXWear.Text;
            numericWear26.Text = numericXWear.Text;
            numericWear27.Text = numericXWear.Text;
            numericWear28.Text = numericXWear.Text;
            numericWear29.Text = numericXWear.Text;
            numericWear30.Text = numericXWear.Text;
        }

        private void buttonXGloves_Click(object sender, EventArgs e)
        {
            numericGloves1.Text = numericXGloves.Text;
            numericGloves2.Text = numericXGloves.Text;
            numericGloves3.Text = numericXGloves.Text;
            numericGloves4.Text = numericXGloves.Text;
            numericGloves5.Text = numericXGloves.Text;
            numericGloves6.Text = numericXGloves.Text;
            numericGloves7.Text = numericXGloves.Text;
            numericGloves8.Text = numericXGloves.Text;
            numericGloves9.Text = numericXGloves.Text;
            numericGloves10.Text = numericXGloves.Text;
            numericGloves11.Text = numericXGloves.Text;
            numericGloves12.Text = numericXGloves.Text;
            numericGloves13.Text = numericXGloves.Text;
            numericGloves14.Text = numericXGloves.Text;
            numericGloves15.Text = numericXGloves.Text;
            numericGloves16.Text = numericXGloves.Text;
            numericGloves17.Text = numericXGloves.Text;
            numericGloves18.Text = numericXGloves.Text;
            numericGloves19.Text = numericXGloves.Text;
            numericGloves20.Text = numericXGloves.Text;
            numericGloves21.Text = numericXGloves.Text;
            numericGloves22.Text = numericXGloves.Text;
            numericGloves23.Text = numericXGloves.Text;
            numericGloves24.Text = numericXGloves.Text;
            numericGloves25.Text = numericXGloves.Text;
            numericGloves26.Text = numericXGloves.Text;
            numericGloves27.Text = numericXGloves.Text;
            numericGloves28.Text = numericXGloves.Text;
            numericGloves29.Text = numericXGloves.Text;
            numericGloves30.Text = numericXGloves.Text;
        }

        private void buttonXAccessories_Click(object sender, EventArgs e)
        {
            numericAccessories1.Text = numericXAccessories.Text;
            numericAccessories2.Text = numericXAccessories.Text;
            numericAccessories3.Text = numericXAccessories.Text;
            numericAccessories4.Text = numericXAccessories.Text;
            numericAccessories5.Text = numericXAccessories.Text;
            numericAccessories6.Text = numericXAccessories.Text;
            numericAccessories7.Text = numericXAccessories.Text;
            numericAccessories8.Text = numericXAccessories.Text;
            numericAccessories9.Text = numericXAccessories.Text;
            numericAccessories10.Text = numericXAccessories.Text;
            numericAccessories11.Text = numericXAccessories.Text;
            numericAccessories12.Text = numericXAccessories.Text;
            numericAccessories13.Text = numericXAccessories.Text;
            numericAccessories14.Text = numericXAccessories.Text;
            numericAccessories15.Text = numericXAccessories.Text;
            numericAccessories16.Text = numericXAccessories.Text;
            numericAccessories17.Text = numericXAccessories.Text;
            numericAccessories18.Text = numericXAccessories.Text;
            numericAccessories19.Text = numericXAccessories.Text;
            numericAccessories20.Text = numericXAccessories.Text;
            numericAccessories21.Text = numericXAccessories.Text;
            numericAccessories22.Text = numericXAccessories.Text;
            numericAccessories23.Text = numericXAccessories.Text;
            numericAccessories24.Text = numericXAccessories.Text;
            numericAccessories25.Text = numericXAccessories.Text;
            numericAccessories26.Text = numericXAccessories.Text;
            numericAccessories27.Text = numericXAccessories.Text;
            numericAccessories28.Text = numericXAccessories.Text;
            numericAccessories29.Text = numericXAccessories.Text;
            numericAccessories30.Text = numericXAccessories.Text;
        }
        private void checkBoxHammerFront_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHammerFront.Checked == true)
                numericRORWAb.Value += 1;

            if (checkBoxHammerFront.Checked == false)
                numericRORWAb.Value -= 1;
        }

        private void checkBoxHammerMiniMario_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHammerMiniMario.Checked == true)
                numericRORWAb.Value += 2;

            if (checkBoxHammerMiniMario.Checked == false)
                numericRORWAb.Value -= 2;
        }

        private void checkBoxHammerMoleMario_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHammerMoleMario.Checked == true)
                numericRORWAb.Value += 4;

            if (checkBoxHammerMoleMario.Checked == false)
                numericRORWAb.Value -= 4;
        }

        private void checkBoxSpinJump_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSpinJump.Checked == true)
                numericRORWAb.Value += 8;

            if (checkBoxSpinJump.Checked == false)
                numericRORWAb.Value -= 8;
        }

        private void checkBoxSideDrill_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSideDrill.Checked == true)
                numericRORWAb.Value += 16;

            if (checkBoxSideDrill.Checked == false)
                numericRORWAb.Value -= 16;
        }

        private void checkBoxBallHop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBallHop.Checked == true)
                numericRORWAb.Value += 32;

            if (checkBoxBallHop.Checked == false)
                numericRORWAb.Value -= 32;
        }

        private void checkBoxDWBButton_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWBButton.Checked == true)
                numericRODWAb.Value += 4;

            if (checkBoxDWBButton.Checked == false)
                numericRODWAb.Value -= 4;
        }

        private void checkBoxDWDrop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWDrop.Checked == true)
                numericRODWAb.Value += 4096;

            if (checkBoxDWDrop.Checked == false)
                numericRODWAb.Value -= 4096;
        }

        private void checkBoxDWStack_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWStack.Checked == true)
                numericRODWAb.Value += 8;

            if (checkBoxDWStack.Checked == false)
                numericRODWAb.Value -= 8;
        }

        private void checkBoxDWStackGP_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWStackGP.Checked == true)
                numericRODWAb.Value += 64;

            if (checkBoxDWStackGP.Checked == false)
                numericRODWAb.Value -= 64;
        }

        private void checkBoxDWStackSJ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWStackSJ.Checked == true)
                numericRODWAb.Value += 128;

            if (checkBoxDWStackSJ.Checked == false)
                numericRODWAb.Value -= 128;
        }

        private void checkBoxDWCone_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWCone.Checked == true)
                numericRODWAb.Value += 16;

            if (checkBoxDWCone.Checked == false)
                numericRODWAb.Value -= 16;
        }

        private void checkBoxDWConeJ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWConeJ.Checked == true)
                numericRODWAb.Value += 256;

            if (checkBoxDWConeJ.Checked == false)
                numericRODWAb.Value -= 256;
        }

        private void checkBoxDWConeT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWConeT.Checked == true)
                numericRODWAb.Value += 512;

            if (checkBoxDWConeT.Checked == false)
                numericRODWAb.Value -= 512;
        }

        private void checkBoxDWBall_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWBall.Checked == true)
                numericRODWAb.Value += 32;

            if (checkBoxDWBall.Checked == false)
                numericRODWAb.Value -= 32;
        }

        private void checkBoxDWBallS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWBallS.Checked == true)
                numericRODWAb.Value += 1024;

            if (checkBoxDWBallS.Checked == false)
                numericRODWAb.Value -= 1024;
        }

        private void checkBoxDWBallH_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWBallH.Checked == true)
                numericRODWAb.Value += 2048;

            if (checkBoxDWBallH.Checked == false)
                numericRODWAb.Value -= 2048;
        }

        private void checkBoxDWAntigrav_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWAntigrav.Checked == true)
                numericRODWAb.Value += 8192;

            if (checkBoxDWAntigrav.Checked == false)
                numericRODWAb.Value -= 8192;
        }

        private void checkBoxAbiltiesOnOff_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAbiltiesOnOff.Checked != true)
            {
                checkBoxHammerFront.Checked = false;
                checkBoxHammerMiniMario.Checked = false;
                checkBoxHammerMoleMario.Checked = false;
                checkBoxSpinJump.Checked = false;
                checkBoxSideDrill.Checked = false;
                checkBoxBallHop.Checked = false;
                checkBoxDWBButton.Checked = false;
                checkBoxDWDrop.Checked = false;
                checkBoxDWStack.Checked = false;
                checkBoxDWStackGP.Checked = false;
                checkBoxDWStackSJ.Checked = false;
                checkBoxDWCone.Checked = false;
                checkBoxDWConeJ.Checked = false;
                checkBoxDWConeT.Checked = false;
                checkBoxDWBall.Checked = false;
                checkBoxDWBallS.Checked = false;
                checkBoxDWBallH.Checked = false;
                checkBoxDWAntigrav.Checked = false;
            }
            else
            {
                checkBoxHammerFront.Checked = true;
                checkBoxHammerMiniMario.Checked = true;
                checkBoxHammerMoleMario.Checked = true;
                checkBoxSpinJump.Checked = true;
                checkBoxSideDrill.Checked = true;
                checkBoxBallHop.Checked = true;
                checkBoxDWBButton.Checked = true;
                checkBoxDWDrop.Checked = true;
                checkBoxDWStack.Checked = true;
                checkBoxDWStackGP.Checked = true;
                checkBoxDWStackSJ.Checked = true;
                checkBoxDWCone.Checked = true;
                checkBoxDWConeJ.Checked = true;
                checkBoxDWConeT.Checked = true;
                checkBoxDWBall.Checked = true;
                checkBoxDWBallS.Checked = true;
                checkBoxDWBallH.Checked = true;
                checkBoxDWAntigrav.Checked = true;
            }
        }

        private void checkBoxNBCUnlockFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNBCUnlockFlag.Checked == true)
                numericRONBCUnlock.Value += 64;

            if (checkBoxNBCUnlockFlag.Checked == false)
                numericRONBCUnlock.Value -= 64;
        }

        private void numericUniversalBadgeCount2_ValueChanged(object sender, EventArgs e)
        {
                numericUniversalBadgeCount1.Value = numericUniversalBadgeCount2.Value;
        }

        private void numericUniversalBadgeCount1_ValueChanged(object sender, EventArgs e)
        {
            numericUniversalBadgeCount2.Value = numericUniversalBadgeCount1.Value;
        }

        private void checkBoxMGearSlot2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMGearSlot2.Checked == true)
                numericROMGearSlot.Value += 16;

            if (checkBoxMGearSlot2.Checked == false)
                numericROMGearSlot.Value -= 16;
        }

        private void checkBoxMGearSlot1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMGearSlot1.Checked == true)
                checkBoxMGearSlot2.Enabled = true;

            if (checkBoxMGearSlot1.Checked == false)
                checkBoxMGearSlot2.Checked = false;

            if (checkBoxMGearSlot1.Checked == false)
                checkBoxMGearSlot2.Enabled = false;

            if (checkBoxMGearSlot1.Checked == true)
                numericROMGearSlot.Value += 16;

            if (checkBoxMGearSlot1.Checked == false)
                numericROMGearSlot.Value -= 16;
        }

        private void checkBoxLGearSlot1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLGearSlot1.Checked == true)
            {
                checkBoxLGearSlot2.Enabled = true;
                numericROLGearSlot.Value += 16;
            }

            if (checkBoxLGearSlot1.Checked == false)
            {
                checkBoxLGearSlot2.Checked = false;
                checkBoxLGearSlot2.Enabled = false;
                numericROLGearSlot.Value -= 16;
            }
        }

        private void comboBoxMShellBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMShellBonus.SelectedIndex == 0)
            {
                comboBoxMFlowerBonus.Enabled = false;
                comboBoxMFlowerBonus.SelectedIndex = 0;
                comboBoxMStarBonus.Enabled = false;
                comboBoxMStarBonus.SelectedIndex = 0;
                comboBoxMRainbowBonus.Enabled = false;
                comboBoxMRainbowBonus.SelectedIndex = 0;
                comboBoxMExtraBonus.Enabled = false;
                comboBoxMExtraBonus.SelectedIndex = 0;
                numericRORankupBonusCombo1.Value = 0;
            }
            else if (comboBoxMShellBonus.SelectedIndex != 0)
            {
                numericRORankupBonusCombo1.Value = 57344;
                comboBoxMFlowerBonus.Enabled = true;
            }

            if (comboBoxMShellBonus.SelectedIndex == 2)
                numericRORankupBonusCombo1.Value += 1;

            if (comboBoxMShellBonus.SelectedIndex == 3)
                numericRORankupBonusCombo1.Value += 2;

            if (comboBoxMShellBonus.SelectedIndex == 4)
                numericRORankupBonusCombo1.Value += 3;

            if (comboBoxMShellBonus.SelectedIndex == 5)
                numericRORankupBonusCombo1.Value += 4;

            if (comboBoxMShellBonus.SelectedIndex == 6)
                numericRORankupBonusCombo1.Value += 5;

            if (comboBoxMShellBonus.SelectedIndex == 7)
                numericRORankupBonusCombo1.Value += 6;

            if (comboBoxMShellBonus.SelectedIndex == 8)
                numericRORankupBonusCombo1.Value += 7;

            if (comboBoxMShellBonus.SelectedIndex == 9)
                numericRORankupBonusCombo1.Value += 8;

            if (comboBoxMShellBonus.SelectedIndex == 10)
                numericRORankupBonusCombo1.Value += 9;

            if (comboBoxMShellBonus.SelectedIndex == 11)
                numericRORankupBonusCombo1.Value += 10;

            if (comboBoxMShellBonus.SelectedIndex == 12)
                numericRORankupBonusCombo1.Value += 11;

            if (comboBoxMShellBonus.SelectedIndex == 13)
                numericRORankupBonusCombo1.Value += 12;

            if (comboBoxMShellBonus.SelectedIndex == 14)
                numericRORankupBonusCombo1.Value += 13;

            if (comboBoxMShellBonus.SelectedIndex == 15)
                numericRORankupBonusCombo1.Value += 14;
        }

        private void comboBoxMFlowerBonus_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (comboBoxMFlowerBonus.SelectedIndex == 0)
                {
                    comboBoxMStarBonus.Enabled = false;
                    comboBoxMStarBonus.SelectedIndex = 0;
                    comboBoxMRainbowBonus.Enabled = false;
                    comboBoxMRainbowBonus.SelectedIndex = 0;
                    comboBoxMExtraBonus.Enabled = false;
                    comboBoxMExtraBonus.SelectedIndex = 0;
                    numericRORankupBonusCombo2.Value = 0;
                }
                else if (comboBoxMFlowerBonus.SelectedIndex != 0)
                {
                    numericRORankupBonusCombo2.Value = 57344;
                    comboBoxMStarBonus.Enabled = true;
                }

                if (comboBoxMFlowerBonus.SelectedIndex == 2)
                    numericRORankupBonusCombo2.Value += 1;

                if (comboBoxMFlowerBonus.SelectedIndex == 3)
                    numericRORankupBonusCombo2.Value += 2;

                if (comboBoxMFlowerBonus.SelectedIndex == 4)
                    numericRORankupBonusCombo2.Value += 3;

                if (comboBoxMFlowerBonus.SelectedIndex == 5)
                    numericRORankupBonusCombo2.Value += 4;

                if (comboBoxMFlowerBonus.SelectedIndex == 6)
                    numericRORankupBonusCombo2.Value += 5;

                if (comboBoxMFlowerBonus.SelectedIndex == 7)
                    numericRORankupBonusCombo2.Value += 6;

                if (comboBoxMFlowerBonus.SelectedIndex == 8)
                    numericRORankupBonusCombo2.Value += 7;

                if (comboBoxMFlowerBonus.SelectedIndex == 9)
                    numericRORankupBonusCombo2.Value += 8;

                if (comboBoxMFlowerBonus.SelectedIndex == 10)
                    numericRORankupBonusCombo2.Value += 9;

                if (comboBoxMFlowerBonus.SelectedIndex == 11)
                    numericRORankupBonusCombo2.Value += 10;

                if (comboBoxMFlowerBonus.SelectedIndex == 12)
                    numericRORankupBonusCombo2.Value += 11;

                if (comboBoxMFlowerBonus.SelectedIndex == 13)
                    numericRORankupBonusCombo2.Value += 12;

                if (comboBoxMFlowerBonus.SelectedIndex == 14)
                    numericRORankupBonusCombo2.Value += 13;

                if (comboBoxMFlowerBonus.SelectedIndex == 15)
                    numericRORankupBonusCombo2.Value += 14;
            }

        private void comboBoxMStarBonus_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxMStarBonus.SelectedIndex == 0)
            {
                comboBoxMRainbowBonus.Enabled = false;
                comboBoxMRainbowBonus.SelectedIndex = 0;
                comboBoxMExtraBonus.Enabled = false;
                comboBoxMExtraBonus.SelectedIndex = 0;
                numericRORankupBonusCombo3.Value = 0;
            }
            else if (comboBoxMStarBonus.SelectedIndex != 0)
            {
                numericRORankupBonusCombo3.Value = 57344;
                comboBoxMRainbowBonus.Enabled = true;
            }

            if (comboBoxMStarBonus.SelectedIndex == 2)
                numericRORankupBonusCombo3.Value += 1;

            if (comboBoxMStarBonus.SelectedIndex == 3)
                numericRORankupBonusCombo3.Value += 2;

            if (comboBoxMStarBonus.SelectedIndex == 4)
                numericRORankupBonusCombo3.Value += 3;

            if (comboBoxMStarBonus.SelectedIndex == 5)
                numericRORankupBonusCombo3.Value += 4;

            if (comboBoxMStarBonus.SelectedIndex == 6)
                numericRORankupBonusCombo3.Value += 5;

            if (comboBoxMStarBonus.SelectedIndex == 7)
                numericRORankupBonusCombo3.Value += 6;

            if (comboBoxMStarBonus.SelectedIndex == 8)
                numericRORankupBonusCombo3.Value += 7;

            if (comboBoxMStarBonus.SelectedIndex == 9)
                numericRORankupBonusCombo3.Value += 8;

            if (comboBoxMStarBonus.SelectedIndex == 10)
                numericRORankupBonusCombo3.Value += 9;

            if (comboBoxMStarBonus.SelectedIndex == 11)
                numericRORankupBonusCombo3.Value += 10;

            if (comboBoxMStarBonus.SelectedIndex == 12)
                numericRORankupBonusCombo3.Value += 11;

            if (comboBoxMStarBonus.SelectedIndex == 13)
                numericRORankupBonusCombo3.Value += 12;

            if (comboBoxMStarBonus.SelectedIndex == 14)
                numericRORankupBonusCombo3.Value += 13;

            if (comboBoxMStarBonus.SelectedIndex == 15)
                numericRORankupBonusCombo3.Value += 14;
        }

        private void comboBoxMRainbowBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMRainbowBonus.SelectedIndex == 0)
            {
                comboBoxMExtraBonus.Enabled = false;
                comboBoxMExtraBonus.SelectedIndex = 0;
                numericRORankupBonusCombo4.Value = 0;
            }
            else if (comboBoxMRainbowBonus.SelectedIndex != 0)
            {
                numericRORankupBonusCombo4.Value = 57344;
                comboBoxMExtraBonus.Enabled = true;
            }

            if (comboBoxMRainbowBonus.SelectedIndex == 2)
                numericRORankupBonusCombo4.Value += 1;

            if (comboBoxMRainbowBonus.SelectedIndex == 3)
                numericRORankupBonusCombo4.Value += 2;

            if (comboBoxMRainbowBonus.SelectedIndex == 4)
                numericRORankupBonusCombo4.Value += 3;

            if (comboBoxMRainbowBonus.SelectedIndex == 5)
                numericRORankupBonusCombo4.Value += 4;

            if (comboBoxMRainbowBonus.SelectedIndex == 6)
                numericRORankupBonusCombo4.Value += 5;

            if (comboBoxMRainbowBonus.SelectedIndex == 7)
                numericRORankupBonusCombo4.Value += 6;

            if (comboBoxMRainbowBonus.SelectedIndex == 8)
                numericRORankupBonusCombo4.Value += 7;

            if (comboBoxMRainbowBonus.SelectedIndex == 9)
                numericRORankupBonusCombo4.Value += 8;

            if (comboBoxMRainbowBonus.SelectedIndex == 10)
                numericRORankupBonusCombo4.Value += 9;

            if (comboBoxMRainbowBonus.SelectedIndex == 11)
                numericRORankupBonusCombo4.Value += 10;

            if (comboBoxMRainbowBonus.SelectedIndex == 12)
                numericRORankupBonusCombo4.Value += 11;

            if (comboBoxMRainbowBonus.SelectedIndex == 13)
                numericRORankupBonusCombo4.Value += 12;

            if (comboBoxMRainbowBonus.SelectedIndex == 14)
                numericRORankupBonusCombo4.Value += 13;

            if (comboBoxMRainbowBonus.SelectedIndex == 15)
                numericRORankupBonusCombo4.Value += 14;
        }

        private void comboBoxMExtraBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMExtraBonus.SelectedIndex == 0)
                numericRORankupBonusCombo5.Value = 0;

            else if (comboBoxMExtraBonus.SelectedIndex != 0)
            {
                numericRORankupBonusCombo5.Value = 57344;
            }

            if (comboBoxMExtraBonus.SelectedIndex == 2)
                numericRORankupBonusCombo5.Value += 1;

            if (comboBoxMExtraBonus.SelectedIndex == 3)
                numericRORankupBonusCombo5.Value += 2;

            if (comboBoxMExtraBonus.SelectedIndex == 4)
                numericRORankupBonusCombo5.Value += 3;

            if (comboBoxMExtraBonus.SelectedIndex == 5)
                numericRORankupBonusCombo5.Value += 4;

            if (comboBoxMExtraBonus.SelectedIndex == 6)
                numericRORankupBonusCombo5.Value += 5;

            if (comboBoxMExtraBonus.SelectedIndex == 7)
                numericRORankupBonusCombo5.Value += 6;

            if (comboBoxMExtraBonus.SelectedIndex == 8)
                numericRORankupBonusCombo5.Value += 7;

            if (comboBoxMExtraBonus.SelectedIndex == 9)
                numericRORankupBonusCombo5.Value += 8;

            if (comboBoxMExtraBonus.SelectedIndex == 10)
                numericRORankupBonusCombo5.Value += 9;

            if (comboBoxMExtraBonus.SelectedIndex == 11)
                numericRORankupBonusCombo5.Value += 10;

            if (comboBoxMExtraBonus.SelectedIndex == 12)
                numericRORankupBonusCombo5.Value += 11;

            if (comboBoxMExtraBonus.SelectedIndex == 13)
                numericRORankupBonusCombo5.Value += 12;

            if (comboBoxMExtraBonus.SelectedIndex == 14)
                numericRORankupBonusCombo5.Value += 13;

            if (comboBoxMExtraBonus.SelectedIndex == 15)
                numericRORankupBonusCombo5.Value += 14;
        }

        private void comboBoxLShellBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLShellBonus.SelectedIndex == 0)
            {
                comboBoxLFlowerBonus.Enabled = false;
                comboBoxLFlowerBonus.SelectedIndex = 0;
                comboBoxLStarBonus.Enabled = false;
                comboBoxLStarBonus.SelectedIndex = 0;
                comboBoxLRainbowBonus.Enabled = false;
                comboBoxLRainbowBonus.SelectedIndex = 0;
                comboBoxLExtraBonus.Enabled = false;
                comboBoxLExtraBonus.SelectedIndex = 0;
                numericRORankupBonusCombo6.Value = 0;
            }
            else if (comboBoxLShellBonus.SelectedIndex != 0)
            {
                numericRORankupBonusCombo6.Value = 57344;
                comboBoxLFlowerBonus.Enabled = true;
            }

            if (comboBoxLShellBonus.SelectedIndex == 2)
                numericRORankupBonusCombo6.Value += 1;

            if (comboBoxLShellBonus.SelectedIndex == 3)
                numericRORankupBonusCombo6.Value += 2;

            if (comboBoxLShellBonus.SelectedIndex == 4)
                numericRORankupBonusCombo6.Value += 3;

            if (comboBoxLShellBonus.SelectedIndex == 5)
                numericRORankupBonusCombo6.Value += 4;

            if (comboBoxLShellBonus.SelectedIndex == 6)
                numericRORankupBonusCombo6.Value += 5;

            if (comboBoxLShellBonus.SelectedIndex == 7)
                numericRORankupBonusCombo6.Value += 6;

            if (comboBoxLShellBonus.SelectedIndex == 8)
                numericRORankupBonusCombo6.Value += 7;

            if (comboBoxLShellBonus.SelectedIndex == 9)
                numericRORankupBonusCombo6.Value += 8;

            if (comboBoxLShellBonus.SelectedIndex == 10)
                numericRORankupBonusCombo6.Value += 9;

            if (comboBoxLShellBonus.SelectedIndex == 11)
                numericRORankupBonusCombo6.Value += 10;

            if (comboBoxLShellBonus.SelectedIndex == 12)
                numericRORankupBonusCombo6.Value += 11;

            if (comboBoxLShellBonus.SelectedIndex == 13)
                numericRORankupBonusCombo6.Value += 12;

            if (comboBoxLShellBonus.SelectedIndex == 14)
                numericRORankupBonusCombo6.Value += 13;

            if (comboBoxLShellBonus.SelectedIndex == 15)
                numericRORankupBonusCombo6.Value += 14;
        }

        private void comboBoxLFlowerBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLFlowerBonus.SelectedIndex == 0)
            {
                comboBoxLStarBonus.Enabled = false;
                comboBoxLStarBonus.SelectedIndex = 0;
                comboBoxLRainbowBonus.Enabled = false;
                comboBoxLRainbowBonus.SelectedIndex = 0;
                comboBoxLExtraBonus.Enabled = false;
                comboBoxLExtraBonus.SelectedIndex = 0;
                numericRORankupBonusCombo7.Value = 0;
            }
            else if (comboBoxLFlowerBonus.SelectedIndex != 0)
            {
                numericRORankupBonusCombo7.Value = 57344;
                comboBoxLStarBonus.Enabled = true;
            }

            if (comboBoxLFlowerBonus.SelectedIndex == 2)
                numericRORankupBonusCombo7.Value += 1;

            if (comboBoxLFlowerBonus.SelectedIndex == 3)
                numericRORankupBonusCombo7.Value += 2;

            if (comboBoxLFlowerBonus.SelectedIndex == 4)
                numericRORankupBonusCombo7.Value += 3;

            if (comboBoxLFlowerBonus.SelectedIndex == 5)
                numericRORankupBonusCombo7.Value += 4;

            if (comboBoxLFlowerBonus.SelectedIndex == 6)
                numericRORankupBonusCombo7.Value += 5;

            if (comboBoxLFlowerBonus.SelectedIndex == 7)
                numericRORankupBonusCombo7.Value += 6;

            if (comboBoxLFlowerBonus.SelectedIndex == 8)
                numericRORankupBonusCombo7.Value += 7;

            if (comboBoxLFlowerBonus.SelectedIndex == 9)
                numericRORankupBonusCombo7.Value += 8;

            if (comboBoxLFlowerBonus.SelectedIndex == 10)
                numericRORankupBonusCombo7.Value += 9;

            if (comboBoxLFlowerBonus.SelectedIndex == 11)
                numericRORankupBonusCombo7.Value += 10;

            if (comboBoxLFlowerBonus.SelectedIndex == 12)
                numericRORankupBonusCombo7.Value += 11;

            if (comboBoxLFlowerBonus.SelectedIndex == 13)
                numericRORankupBonusCombo7.Value += 12;

            if (comboBoxLFlowerBonus.SelectedIndex == 14)
                numericRORankupBonusCombo7.Value += 13;

            if (comboBoxLFlowerBonus.SelectedIndex == 15)
                numericRORankupBonusCombo7.Value += 14;
        }

        private void comboBoxLStarBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLStarBonus.SelectedIndex == 0)
            {
                comboBoxLRainbowBonus.Enabled = false;
                comboBoxLRainbowBonus.SelectedIndex = 0;
                comboBoxLExtraBonus.Enabled = false;
                comboBoxLExtraBonus.SelectedIndex = 0;
                numericRORankupBonusCombo8.Value = 0;
            }
            else if (comboBoxLStarBonus.SelectedIndex != 0)
            {
                numericRORankupBonusCombo8.Value = 57344;
                comboBoxLRainbowBonus.Enabled = true;
            }

            if (comboBoxLStarBonus.SelectedIndex == 2)
                numericRORankupBonusCombo8.Value += 1;

            if (comboBoxLStarBonus.SelectedIndex == 3)
                numericRORankupBonusCombo8.Value += 2;

            if (comboBoxLStarBonus.SelectedIndex == 4)
                numericRORankupBonusCombo8.Value += 3;

            if (comboBoxLStarBonus.SelectedIndex == 5)
                numericRORankupBonusCombo8.Value += 4;

            if (comboBoxLStarBonus.SelectedIndex == 6)
                numericRORankupBonusCombo8.Value += 5;

            if (comboBoxLStarBonus.SelectedIndex == 7)
                numericRORankupBonusCombo8.Value += 6;

            if (comboBoxLStarBonus.SelectedIndex == 8)
                numericRORankupBonusCombo8.Value += 7;

            if (comboBoxLStarBonus.SelectedIndex == 9)
                numericRORankupBonusCombo8.Value += 8;

            if (comboBoxLStarBonus.SelectedIndex == 10)
                numericRORankupBonusCombo8.Value += 9;

            if (comboBoxLStarBonus.SelectedIndex == 11)
                numericRORankupBonusCombo8.Value += 10;

            if (comboBoxLStarBonus.SelectedIndex == 12)
                numericRORankupBonusCombo8.Value += 11;

            if (comboBoxLStarBonus.SelectedIndex == 13)
                numericRORankupBonusCombo8.Value += 12;

            if (comboBoxLStarBonus.SelectedIndex == 14)
                numericRORankupBonusCombo8.Value += 13;

            if (comboBoxLStarBonus.SelectedIndex == 15)
                numericRORankupBonusCombo8.Value += 14;
        }

        private void comboBoxLRainbowBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLRainbowBonus.SelectedIndex == 0)
            {
                comboBoxLExtraBonus.Enabled = false;
                comboBoxLExtraBonus.SelectedIndex = 0;
                numericRORankupBonusCombo9.Value = 0;
            }
            else if (comboBoxLRainbowBonus.SelectedIndex != 0)
            {
                numericRORankupBonusCombo9.Value = 57344;
                comboBoxLExtraBonus.Enabled = true;
            }

            if (comboBoxLRainbowBonus.SelectedIndex == 2)
                numericRORankupBonusCombo9.Value += 1;

            if (comboBoxLRainbowBonus.SelectedIndex == 3)
                numericRORankupBonusCombo9.Value += 2;

            if (comboBoxLRainbowBonus.SelectedIndex == 4)
                numericRORankupBonusCombo9.Value += 3;

            if (comboBoxLRainbowBonus.SelectedIndex == 5)
                numericRORankupBonusCombo9.Value += 4;

            if (comboBoxLRainbowBonus.SelectedIndex == 6)
                numericRORankupBonusCombo9.Value += 5;

            if (comboBoxLRainbowBonus.SelectedIndex == 7)
                numericRORankupBonusCombo9.Value += 6;

            if (comboBoxLRainbowBonus.SelectedIndex == 8)
                numericRORankupBonusCombo9.Value += 7;

            if (comboBoxLRainbowBonus.SelectedIndex == 9)
                numericRORankupBonusCombo9.Value += 8;

            if (comboBoxLRainbowBonus.SelectedIndex == 10)
                numericRORankupBonusCombo9.Value += 9;

            if (comboBoxLRainbowBonus.SelectedIndex == 11)
                numericRORankupBonusCombo9.Value += 10;

            if (comboBoxLRainbowBonus.SelectedIndex == 12)
                numericRORankupBonusCombo9.Value += 11;

            if (comboBoxLRainbowBonus.SelectedIndex == 13)
                numericRORankupBonusCombo9.Value += 12;

            if (comboBoxLRainbowBonus.SelectedIndex == 14)
                numericRORankupBonusCombo9.Value += 13;

            if (comboBoxLRainbowBonus.SelectedIndex == 15)
                numericRORankupBonusCombo9.Value += 14;
        }

        private void comboBoxLExtraBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLExtraBonus.SelectedIndex == 0)
                numericRORankupBonusCombo10.Value = 0;

            else if (comboBoxLExtraBonus.SelectedIndex != 0)
                numericRORankupBonusCombo10.Value = 57344;

            if (comboBoxLExtraBonus.SelectedIndex == 2)
                numericRORankupBonusCombo10.Value += 1;

            if (comboBoxLExtraBonus.SelectedIndex == 3)
                numericRORankupBonusCombo10.Value += 2;

            if (comboBoxLExtraBonus.SelectedIndex == 4)
                numericRORankupBonusCombo10.Value += 3;

            if (comboBoxLExtraBonus.SelectedIndex == 5)
                numericRORankupBonusCombo10.Value += 4;

            if (comboBoxLExtraBonus.SelectedIndex == 6)
                numericRORankupBonusCombo10.Value += 5;

            if (comboBoxLExtraBonus.SelectedIndex == 7)
                numericRORankupBonusCombo10.Value += 6;

            if (comboBoxLExtraBonus.SelectedIndex == 8)
                numericRORankupBonusCombo10.Value += 7;

            if (comboBoxLExtraBonus.SelectedIndex == 9)
                numericRORankupBonusCombo10.Value += 8;

            if (comboBoxLExtraBonus.SelectedIndex == 10)
                numericRORankupBonusCombo10.Value += 9;

            if (comboBoxLExtraBonus.SelectedIndex == 11)
                numericRORankupBonusCombo10.Value += 10;

            if (comboBoxLExtraBonus.SelectedIndex == 12)
                numericRORankupBonusCombo10.Value += 11;

            if (comboBoxLExtraBonus.SelectedIndex == 13)
                numericRORankupBonusCombo10.Value += 12;

            if (comboBoxLExtraBonus.SelectedIndex == 14)
                numericRORankupBonusCombo10.Value += 13;

            if (comboBoxLExtraBonus.SelectedIndex == 15)
                numericRORankupBonusCombo10.Value += 14;
        }

        private void checkBoxLGearSlot2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLGearSlot2.Checked == true)
                numericROLGearSlot.Value += 16;

            if (checkBoxLGearSlot2.Checked == false)
                numericROLGearSlot.Value -= 16;
        }

        private void buttonMSetLvl1_Click(object sender, EventArgs e)
        {
            numericMCurHP.Value = 24;
            numericMCurBP.Value = 8;
            numericLMaxHP.Value = 24;
            numericLMaxBP.Value = 8;
            numericMPower.Value = 20;
            numericMDef.Value = 13;
            numericMSpeed.Value = 16;
            numericMStache.Value = 20;
            numericMBeanHP.Value = 0;
            numericMBeanBP.Value = 0;
            numericMBeanPow.Value = 0;
            numericMBeanDef.Value = 0;
            numericMBeanSpeed.Value = 0;
            numericMBeanStache.Value = 0;
            numericMLvlUpHP.Value = 0;
            numericMLvlUpBP.Value = 0;
            numericMLvlUpPow.Value = 0;
            numericMLvlUpDef.Value = 0;
            numericMLvlUpSpeed.Value = 0;
            numericMLvlUpStache.Value = 0;
            numericMLevel.Value = 1;
            numericMExperience.Value = 0;
            comboBoxMShellBonus.SelectedIndex = 0;
            checkBoxMGearSlot1.Checked = false;
            checkBoxMGearSlot2.Checked = false;
            numericUniversalBadgeCount1.Value = 2;
        }

        private void buttonMSetLevel100_Click(object sender, EventArgs e)
        {
            numericMCurHP.Value = 999;
            numericMCurBP.Value = 999;
            numericMMaxHP.Value = 999;
            numericMMaxBP.Value = 999;
            numericMPower.Value = 999;
            numericMDef.Value = 999;
            numericMSpeed.Value = 999;
            numericMStache.Value = 999;
            numericMBeanHP.Value = 999;
            numericMBeanBP.Value = 999;
            numericMBeanPow.Value = 999;
            numericMBeanDef.Value = 999;
            numericMBeanSpeed.Value = 999;
            numericMBeanStache.Value = 999;
            numericMLvlUpHP.Value = 999;
            numericMLvlUpBP.Value = 999;
            numericMLvlUpPow.Value = 999;
            numericMLvlUpDef.Value = 999;
            numericMLvlUpSpeed.Value = 999;
            numericMLvlUpStache.Value = 999;
            numericMLevel.Value = 100;
            numericMExperience.Value = 3000000;
        }

        private void buttonLSetLvl1_Click(object sender, EventArgs e)
        {
            numericLCurHP.Value = 30;
            numericLCurBP.Value = 6;
            numericLMaxHP.Value = 30;
            numericLMaxBP.Value = 6;
            numericLPow.Value = 16;
            numericLDef.Value = 17;
            numericLSpeed.Value = 10;
            numericLStache.Value = 30;
            numericLBeanHP.Value = 0;
            numericLBeanBP.Value = 0;
            numericLBeanPow.Value = 0;
            numericLBeanDef.Value = 0;
            numericLBeanSpeed.Value = 0;
            numericLBeanStache.Value = 0;
            numericLLvlUpHP.Value = 0;
            numericLLvlUpBP.Value = 0;
            numericLLvlUpPow.Value = 0;
            numericLLvlUpDef.Value = 0;
            numericLLvlUpSpeed.Value = 0;
            numericLLvlUpStache.Value = 0;
            numericLLevel.Value = 1;
            numericLExperience.Value = 0;
            comboBoxLShellBonus.SelectedIndex = 0;
            checkBoxLGearSlot1.Checked = false;
            checkBoxLGearSlot2.Checked = false;
            numericUniversalBadgeCount1.Value = 2;

        }

        private void buttonLSetMax_Click(object sender, EventArgs e)
        {
            numericLCurHP.Value = 999;
            numericLCurBP.Value = 999;
            numericLMaxHP.Value = 999;
            numericLMaxBP.Value = 999;
            numericLPow.Value = 999;
            numericLDef.Value = 999;
            numericLSpeed.Value = 999;
            numericLStache.Value = 999;
            numericLBeanHP.Value = 999;
            numericLBeanBP.Value = 999;
            numericLBeanPow.Value = 999;
            numericLBeanDef.Value = 999;
            numericLBeanSpeed.Value = 999;
            numericLBeanStache.Value = 999;
            numericLLvlUpHP.Value = 999;
            numericLLvlUpBP.Value = 999;
            numericLLvlUpPow.Value = 999;
            numericLLvlUpDef.Value = 999;
            numericLLvlUpSpeed.Value = 999;
            numericLLvlUpStache.Value = 999;
            numericLLevel.Value = 100;
            numericLExperience.Value = 3002500;

        }

        private void checkBoxAllowPausing_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBoxAllowPausing.Checked == true)
                    numericRODWAb.Value += 16384;

                if (checkBoxAllowPausing.Checked == false)
                    numericRODWAb.Value -= 16384;
            }
        }

        private void checkBoxHardMode_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBoxHardMode.Checked == true)
                    numericRODWAb.Value += 2;

                if (checkBoxHardMode.Checked == false)
                    numericRODWAb.Value -= 2;
            }
        }

        private void checkBoxHaveBadges_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBoxHaveBadges.Checked == true)
                    numericROHaveBadges.Value += 32;

                if (checkBoxHaveBadges.Checked == false)
                    numericROHaveBadges.Value -= 32;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stats_Information_Box f2 = new Stats_Information_Box();
            f2.ShowDialog(); // Shows Stats Infromation Box
        }

        private void buttonLInformation_Click(object sender, EventArgs e)
        {
            Stats_Information_Box f2 = new Stats_Information_Box();
            f2.ShowDialog(); // Shows Stats Infromation Box
        }
    }
}
