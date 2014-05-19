using System;
using System.Windows;

namespace HTMLUICompiler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HTMLParser.ParserSettings settings;
            settings.m_rootPath = @"C:\SDK\HTMLUICompiler\HTMLUICompiler\";
            m_parser = new HTMLParser(settings);
        }

        private void CompileUIFile(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Start Compiling");
            m_parser.CompileHTMLFile(InputFileTextBox.Text);
        }

        private void BrowseForInputFile(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Browse Input File");
        }

        private void BrowseForOutputFile(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Browse Output File");
        }

        private HTMLParser m_parser;
    }
}
