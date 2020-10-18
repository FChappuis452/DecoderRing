using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DecoderRing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string output;
        public MainWindow()
        {
            InitializeComponent();
        }


     
        private void encodeBtn_Click(object sender, RoutedEventArgs e)
        {
            int key = strToHex(keyTxtBx.Text);
            output = Transcode(inputTxtBx.Text, key, true);
            outputTxtBx.Text = output;
        }

        
        
        
        private void decodeBtn_Click(object sender, RoutedEventArgs e)
        {
            int key = strToHex(keyTxtBx.Text);
            output = Transcode(inputTxtBx.Text, key, false);
            outputTxtBx.Text = output;
        }

        
        
        
        private void inputTxtBx_GotFocus(object sender, RoutedEventArgs e)
        {
            inputTxtBx.Clear();
        }

        private void keyTxtBx_GotFocus(object sender, RoutedEventArgs e)
        {
            keyTxtBx.Clear();
        }




        /// <summary>
        /// This will usee the input text along with the key to decode
        /// or encode the message in the input box
        /// </summary>
        /// <param name="input">The string to be encoded/decoded</param>
        /// <param name="key">The int key to decode or encode</param>
        /// <param name="func">True for encoding false for decoding</param>
        /// <returns></returns>
        private string Transcode(string input, int key, bool func)
        {
            char[] strArray;
            string transcodedStr = "";

            strArray = input.ToCharArray();

            foreach (char c in strArray)
            {
                int character = c;
                if (func)
                {
                    character += key;
                }
                else
                {
                    character -= key;
                }

                transcodedStr += (char)character;
            }
            return transcodedStr;
        }




        /// <summary>
        /// This will take the text in the key textbox and  make it an int
        /// </summary>
        /// <param name="input">The Key textbox text</param>
        /// <returns></returns>
        private int strToHex(string input)
        {
            input = input.ToUpper();
            byte[] stringByte = Encoding.Default.GetBytes(input);
            byte bigByte = 0;
            foreach (byte b in stringByte)
            {
                bigByte += b;
            }

            return Convert.ToInt32(bigByte);
        }
    }
}
