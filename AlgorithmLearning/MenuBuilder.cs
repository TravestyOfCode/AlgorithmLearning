using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLearning
{
    public class MenuBuilder
    {
        private StringBuilder builder;

        public char BorderChar;

        public int Width;

        private string PaddingSpace;
        private int _Padding;
        public int Padding
        {
            get => _Padding;
            set
            {
                _Padding = value;
                PaddingSpace = new string(' ', value);
            }
        }

        private int AvailableSpace => Width - (Padding * 2 + 2);

        public MenuBuilder(char borderChar) : this(80, borderChar, 1) { }
        public MenuBuilder(int width = 80, char borderChar = '/', int padding = 1)
        {
            BorderChar = borderChar;
            Width = width;
            Padding = padding;
        }

        public string ToString(string message)
        {
            builder = new StringBuilder();

            // Create the top line
            CreateHeader();

            // Append our line
            AppendLine(message);

            // Create the bottom line 
            CreateFooter();

            return builder.ToString();
        }

        public string ToString(string[] messages, bool addLineBetween = true)
        {
            builder = new StringBuilder();

            CreateHeader();

            foreach (var message in messages)
            {
                AppendLine(message);
                if (addLineBetween)
                    AppendLine(" ");
            }

            CreateFooter();

            return builder.ToString();
        }

        private void CreateHeader()
        {
            builder.AppendLine(new string(BorderChar, Width));
            builder.AppendLine($"{BorderChar}{new string(' ', Width - 2)}{BorderChar}");

        }

        private void AppendLine(string message)
        {
            // Check to see if the message is too long
            while (message.Length > 0)// .IsNullOrWhiteSpace(message))
            {
                // Is the message too long for our line?
                while (message.Length > AvailableSpace)
                {
                    // Split the string based on space remaining between BorderChar + Padding on each side
                    // Checking for whitespace for break.
                    string split = message.Substring(0, AvailableSpace);

                    if(!char.IsWhiteSpace(split.Last()))
                    {
                        int lastSpace = split.LastIndexOf(' ');
                        if(lastSpace > 0)
                        {
                            split = message.Substring(0, lastSpace);
                        }
                    }

                    message = message.Substring(split.Length, message.Length - split.Length).Trim();

                    // Display our split
                    builder.AppendLine($"{BorderChar}{PaddingSpace}{split}{new string(' ', AvailableSpace - split.Length)}{PaddingSpace}{BorderChar}");
                }

                // Display the message with borders and padding
                builder.AppendLine($"{BorderChar}{PaddingSpace}{message}{new string(' ', AvailableSpace - message.Length)}{PaddingSpace}{BorderChar}");

                // Clear our message
                message = string.Empty;
            }
        }

        private void CreateFooter()
        {
            builder.AppendLine($"{BorderChar}{new string(' ', Width - 2)}{BorderChar}");
            builder.AppendLine(new string(BorderChar, Width));

        }
    }
}
