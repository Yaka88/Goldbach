using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Goldbach
{
    public partial class frmMain : Form
    {
        bool[] intPrimeCol;
        int intNoBase = 6;
        //
        /*  struct PPData
          {
              public int Even;
              public int PPNumber;
              public List<int> PrimePair;
          }*/

        public frmMain()
        {
            InitializeComponent();
        }

        string ToSenary(int intNumber)   //  to base 6
        {
            if (intNumber < intNoBase)
                return intNumber.ToString("00");
            StringBuilder strNumber = new StringBuilder("");
            while (intNumber > 0)
            {
                strNumber.Insert(0,intNumber % intNoBase); // 1
                intNumber /= intNoBase;
            }
            return strNumber.ToString();
        }
        int ParseSenary(string strNumber)
        {
            int intNumber = 0;
            for(int i = 0; i < strNumber.Length; i++)
            {
                intNumber = intNumber * intNoBase + strNumber[i] - 48;
            }
            return intNumber;
        }
        private void btnPrime_Click(object sender, EventArgs e)
        {
            int intEven =  checkBox1.Checked? ParseSenary(txtNumber.Text):int.Parse(txtNumber.Text);
            int intSqrtEven = (int)Math.Sqrt(intEven);
            int intCount = 0;
            richTextPrimePair.Text = "";
            intPrimeCol = new bool[intEven];
            //StringBuilder strPrimeCol = new StringBuilder();
            richTextPrime.Clear();
            richTextPrime.AppendText(" 01\t");
            DateTime dtStart = DateTime.Now;
            for(int i = 3; i < intEven; i=i+2)
            {
                if (intPrimeCol[i] == false)  //false means Prime
                {
                    intCount++;
                    if (i <= intSqrtEven)
                    {
                        int istep = i << 1;
                        for (int j = i * i; j < intEven; j = j + istep)//for (int j = i << 1; j < intEven; j = j + i)
                            intPrimeCol[j] = true;
                    }
                }

                if (intCount < byte.MaxValue) //save time
                {   
                    if (checkBox1.Checked)
                    {
                        richTextPrime.SelectionColor = Color.Black;
                        richTextPrime.AppendText(ToSenary(i - 1));
                        richTextPrime.AppendText("\t");
                    }
                    if (i % intNoBase == 1)
                        richTextPrime.AppendText("\n ");
                    richTextPrime.SelectionColor = intPrimeCol[i] ? Color.Black : Color.Red;
                    //richTextPrime.AppendText(ToSenary(i));
                    richTextPrime.AppendText(checkBox1.Checked?ToSenary(i):i.ToString("00"));
                    richTextPrime.AppendText("\t");
                }
            }
            txtTime.Text = (DateTime.Now - dtStart).TotalMilliseconds.ToString("N4");
            txtCount.Text = intCount.ToString();
           // richTextPrime.Text = strPrimeCol.ToString(); 

        }

        private void btnEven_Click(object sender, EventArgs e)
        {

            int intEven = intPrimeCol.Length;
            StringBuilder strEvenCol = new StringBuilder();
            int[] intEvenCol = new int[intEven + 1]; // pp count
            for (int i = 5; i <= (intEven >> 1); i = i + 2)  //step = 2;//ignore 3
            {
                if (intPrimeCol[i] == false)
                {
                    for (int j = i; j <= intEven - i; j = j + 2)
                    {
                        if (intPrimeCol[j] == false)// && i != j)  相同质数不计算
                        {
                            intEvenCol[i + j]++;
                           //  if(intEvenCol[i + j]==0)
                           //  intEvenCol[i + j] = i;
                        }
                    }
                }
            }

            int intLimite = Math.Min(short.MaxValue, intEven); //save time)
            for (int i = 2; i <= intLimite; i = i + 2)
            {
                strEvenCol.Append(intEvenCol[i].ToString("00  "));
                if (i % 6 == 0)
                {
                    strEvenCol.Append("\t");
                    if (i % 30 == 0)
                        strEvenCol.Append("\r\n");
                }
            }
            richTextPrimePair.Text = strEvenCol.ToString();
            DecideExcludePP(ref intEvenCol);
        }
        void DecideExcludePP(ref int[] intEvenCol)//例外pp数
        {
            int intEven = intPrimeCol.Length;
            int intBase = 2, intStep = 2, intBaseIndex = 0;// int intBase = 2
            int intExclude = 0;
            for (int i = 3; intBase * i <= intEven; i = i + 2)  //step = 2;
            {
                if (intPrimeCol[i] == false)
                {
                    intStep = intBase;
                    intBase *= i;
                    intBaseIndex = intBase;
                    for (int j = intStep; j < intEven && intBaseIndex <= intEven; j += intStep)
                    {
                        if (j < intBaseIndex)
                        {
                            if (intEvenCol[j] > intEvenCol[intBaseIndex])
                            {
                                intExclude++;
                            }
                        }
                        else
                        {
                            intBaseIndex += intBase;
                        }
                    }

                }
            }
            txtEvenCount.Text = string.Format("Ex {0}", intExclude);
        }

        bool IsSucceed(int intEven, int intBase)
        {
            for (int i = 5; i <= (intEven >> 1); i = i + 2)//pass  1，3
            {
                if (intPrimeCol[i] == false && intPrimeCol[intEven - i] == false)
                {
                    if(!intPrimeCol[i + intBase])// || !intPrimeCol[intEven - i + intBase])//小质数+6依然为质数
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        void DecideSucceedPP()   //PP对小质数 + intBase 仍可构成PP对
        {
            int intBase = 6; //  2*3*5*7*11
            
            for(int i = intBase <<1; i <= intPrimeCol.Length; i += 2)
            {
                if(IsSucceed(i, intBase) == false)
                {
                    txtEvenCount.Text = string.Format("Ex {0}", i);
                    return;
                }
            }
            txtEvenCount.Text = string.Format("Y {0}", intPrimeCol.Length);
        }
        private void btnPrimePair_Click(object sender, EventArgs e)
        {
            int intEven = checkBox1.Checked ? ParseSenary(txtNumber.Text) : int.Parse(txtNumber.Text);
            if (intEven > intPrimeCol.Length)
                return;
            int intPrimePairCount = 0;
            int intPICount = 0;
            //int intPrimeLow = 0;
          //  for (intEven = 10; intEven <= intPrimeCol.Length; intEven += 2)//for test ignore 6.8
            {
                StringBuilder strEvenCol = new StringBuilder();
                intPrimePairCount = 0;
                intPICount = 0;
                strEvenCol.Append(checkBox1.Checked ? ToSenary(intEven) : intEven.ToString());
                for (int i = 5; i <= (intEven >> 1); i += 2) //ignore 3 
                {
                    if (intPrimeCol[i] == false)
                    {
                        intPICount++;
                        if (intPrimeCol[intEven - i] == false)
                        {
                            intPrimePairCount++;
                            strEvenCol.Append("=");
                            strEvenCol.Append(checkBox1.Checked ? ToSenary(i) : i.ToString());
                            strEvenCol.Append("+");
                            strEvenCol.Append(checkBox1.Checked ? ToSenary(intEven - i) : (intEven - i).ToString());

                           /* if (i > intPrimeLow)
                                intPrimeLow = i;
                            break;//for test */
                        }
                    }
                }
                strEvenCol.Append("\r\n");
                //StringBuilder strFactorCol = new StringBuilder(string.Format("pp({0})={1}, PI({2})={3}, ", intEven, intPrimePairCount, intEven >> 1, intPICount));
                
                StringBuilder strFactorCol = new StringBuilder(string.Format("pp({0})={1}, 2", intEven, intPrimePairCount));
                int intTempEven = intEven >> 1;
                for (int j = 2; j <= intTempEven;)
                {
                    if (intPrimeCol[j] == false && (intTempEven % j) == 0)
                    {
                        strFactorCol.Append("*");
                        strFactorCol.Append(j.ToString());
                        intTempEven /= j;
                    }
                    else
                        j++;

                }
                strFactorCol.Append(";");
                
                if (strFactorCol.Length < 20)
                    strFactorCol.Append("\t");
                 richTextPrimePair.Text += strFactorCol.ToString() + strEvenCol.ToString();
                //richTextPrimePair.Text += strFactorCol.ToString() + "\r\n";
            }
            txtEvenCount.Text = intPrimePairCount.ToString();          
        }

        private void btnDecide_Click(object sender, EventArgs e)
        {
            DecideSucceedPP();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            intNoBase = checkBox1.Checked ? 6 : 10;
        }
    }
}
