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
    public partial class Form1 : Form
    {
        public Form1()
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
            byte[] rwsd = ML4E_StringToByteArray(byte.Parse(numericRORWAb.Text).ToString("X8"));
            Array.Reverse(rwsd);
            update_save_open.Position = Convert.ToByte("0", 16);
            update_save_write.Write(rwsd);

            byte[] dwsd = ML4E_StringToByteArray(int.Parse(numericRODWAb.Text).ToString("X8"));
            Array.Reverse(dwsd);
            update_save_open.Position = Convert.ToInt16("1", 16);
            update_save_write.Write(dwsd);

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
                save.Enabled = true;
                box_money.ReadOnly = false;
                buttonMaxItems.Enabled = true;
                FileStream savegame_fs = new FileStream(savegame, FileMode.Open);
                BinaryReader savegame_br = new BinaryReader(savegame_fs);
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

        private void checkBoxHammerFront_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHammerFront.Checked == true)
                _ = numericRORWAb.Value += 1;

            if (checkBoxHammerFront.Checked == false)
                _ = numericRORWAb.Value -= 1;
        }

        private void checkBoxHammerMiniMario_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHammerMiniMario.Checked == true)
                _ = numericRORWAb.Value += 2;

            if (checkBoxHammerMiniMario.Checked == false)
                _ = numericRORWAb.Value -= 2;
        }

        private void checkBoxHammerMoleMario_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHammerMoleMario.Checked == true)
                _ = numericRORWAb.Value += 4;

            if (checkBoxHammerMoleMario.Checked == false)
                _ = numericRORWAb.Value -= 4;
        }

        private void checkBoxSpinJump_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSpinJump.Checked == true)
                _ = numericRORWAb.Value += 8;

            if (checkBoxSpinJump.Checked == false)
                _ = numericRORWAb.Value -= 8;
        }

        private void checkBoxSideDrill_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSideDrill.Checked == true)
                _ = numericRORWAb.Value += 16;

            if (checkBoxSideDrill.Checked == false)
                _ = numericRORWAb.Value -= 16;
        }

        private void checkBoxBallHop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBallHop.Checked == true)
                _ = numericRORWAb.Value += 32;

            if (checkBoxBallHop.Checked == false)
                _ = numericRORWAb.Value -= 32;
        }

        private void checkBoxDWBButton_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWBButton.Checked == true)
                _ = numericRODWAb.Value += 4;

            if (checkBoxDWBButton.Checked == false)
                _ = numericRODWAb.Value -= 4;
        }

        private void checkBoxDWDrop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWDrop.Checked == true)
                _ = numericRODWAb.Value += 4096;

            if (checkBoxDWDrop.Checked == false)
                _ = numericRODWAb.Value -= 4096;
        }

        private void checkBoxDWStack_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWStack.Checked == true)
                _ = numericRODWAb.Value += 8;

            if (checkBoxDWStack.Checked == false)
                _ = numericRODWAb.Value -= 8;
        }

        private void checkBoxDWStackGP_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWStackGP.Checked == true)
                _ = numericRODWAb.Value += 64;

            if (checkBoxDWStackGP.Checked == false)
                _ = numericRODWAb.Value -= 64;
        }

        private void checkBoxDWStackSJ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWStackSJ.Checked == true)
                _ = numericRODWAb.Value += 128;

            if (checkBoxDWStackSJ.Checked == false)
                _ = numericRODWAb.Value -= 128;
        }

        private void checkBoxDWCone_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWCone.Checked == true)
                _ = numericRODWAb.Value += 16;

            if (checkBoxDWCone.Checked == false)
                _ = numericRODWAb.Value -= 16;
        }

        private void checkBoxDWConeJ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWConeJ.Checked == true)
                _ = numericRODWAb.Value += 256;

            if (checkBoxDWConeJ.Checked == false)
                _ = numericRODWAb.Value -= 256;
        }

        private void checkBoxDWConeT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWConeT.Checked == true)
                _ = numericRODWAb.Value += 512;

            if (checkBoxDWConeT.Checked == false)
                _ = numericRODWAb.Value -= 512;
        }

        private void checkBoxDWBall_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWBall.Checked == true)
                _ = numericRODWAb.Value += 32;

            if (checkBoxDWBall.Checked == false)
                _ = numericRODWAb.Value -= 32;
        }

        private void checkBoxDWBallS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWBallS.Checked == true)
                _ = numericRODWAb.Value += 1024;

            if (checkBoxDWBallS.Checked == false)
                _ = numericRODWAb.Value -= 1024;
        }

        private void checkBoxDWBallH_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWBallH.Checked == true)
                _ = numericRODWAb.Value += 2048;

            if (checkBoxDWBallH.Checked == false)
                _ = numericRODWAb.Value -= 2048;
        }

        private void checkBoxDWAntigrav_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDWAntigrav.Checked == true)
                _ = numericRODWAb.Value += 8192;

            if (checkBoxDWAntigrav.Checked == false)
                _ = numericRODWAb.Value -= 8192;
        }
    }
}
