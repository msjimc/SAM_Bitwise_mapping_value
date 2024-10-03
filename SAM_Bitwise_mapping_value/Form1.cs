using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace SAM_Bitwise_mapping_value
{
    public partial class Form1 : Form
    {
        readonly string[] _valuesPositive = { "Paired data", "Both reads mapped as a pair", "Read unmapped", "Mate is unmapped", "Read reverse complemented", "Mate read is reverse complemented", "Read mapped to template", "Read's mate is mapped to template", "This ss a secondary alignment", "Alignment fails quality checks", "PCR or optical duplicate", "Is in supplementary alignment (e.g. aligner specific, could be a portion of a split read or a tied region)" };
        readonly string[] _valuesNegative = { "Single end data", "Not a mapped read pair", "Read mapped", "Mate is mapped", "Read in original orientation", "Mate pair isnt reverse complement", "Read mapped to template", "Read's mate not mapped to template", "This is a secondary alignment", "Alignment fails quality checks", "PCR or optical duplicate", "Is in supplementary alignment (e.g. aligner specific, could be a portion of a split read or a tied region)" };

        public Form1()
        {
            InitializeComponent();
        }

        private void txtFlag_TextChanged(object sender, EventArgs e)
        {
            string[] valuesPositive = _valuesPositive;
            string[] valuesNegative = _valuesNegative;

            txtResult.Clear();
            int value = -1;
            try
            {
              value = Convert.ToInt32(txtFlag.Text.Trim());
                string answer = "";
               if ((value & 1) == 1)
                { answer += valuesPositive[0] + "\r\n"; }
                else
                {
                    answer += valuesNegative[0] + "\r\n";
                    int[] delete = { 1, 5, 7 };
                    valuesNegative=clean(valuesNegative, delete);
                    valuesPositive = clean(valuesPositive, delete);
                }

                if ((value & 2) == 2)
                { answer += valuesPositive[1] + "\r\n"; }
                else
                { answer += valuesNegative[1] + "\r\n"; }

                if ((value & 4) == 4)
                {
                    answer += valuesPositive[2] + "\r\n";   
                    int[] delete = { 4, 6, 8,10 ,11};
                    valuesNegative = clean(valuesNegative, delete);
                    valuesPositive = clean(valuesPositive, delete);
                }
                else 
                {  answer += valuesNegative[2] + "\r\n"; }

                if ((value & 8) == 8)
                { 
                    answer += valuesPositive[3] + "\r\n"; 
                    int[] delete = { 5, 7, 8,10,11};
                    valuesNegative = clean(valuesNegative, delete);
                    valuesPositive = clean(valuesPositive, delete);
                }
                else 
                {  answer += valuesNegative[3] + "\r\n"; }

                if ((value & 16) == 16)
                { answer += valuesPositive[4] + "\r\n"; }
                else { answer += valuesNegative[4] + "\r\n"; }

                if ((value & 32) == 32)
                { answer += valuesPositive[5] + "\r\n"; }
                else { answer += valuesNegative[5] + "\r\n"; }

                if ((value & 64) == 64)
                { answer += valuesPositive[6] + "\r\n"; }
                else { answer += valuesNegative[6] + "\r\n"; }

                if ((value & 128) == 128)
                { answer += valuesPositive[7] + "\r\n"; }
                else { answer += valuesNegative[7] + "\r\n"; }

                if ((value & 256) == 256)
                { answer += valuesPositive[8] + "\r\n"; }
                else { answer += valuesNegative[8] + "\r\n"; }

                if ((value & 512) == 512)
                { answer += valuesPositive[9] + "\r\n"; }
                else { answer += valuesNegative[9] + "\r\n"; }

                if ((value & 1024) == 1024)
                { answer += valuesPositive[10] + "\r\n"; }
                else { answer += valuesNegative[10] + "\r\n"; }

                if ((value & 2048) == 2048)
                { answer += valuesPositive[11] + "\r\n"; }
                else { answer += valuesNegative[11] + "\r\n"; }

                txtResult.Text = answer;

            }
            catch { txtResult.Clear(); }
        }

        private string[] clean(string[] array, int[] delete)
        {
            List<string> result = new List<string>();
            result.AddRange(array);
            foreach (int i in delete)
            {
                result[i] = "NA";
            }
            return result.ToArray();
        }
    }
}
