using System;
using System.Windows;

namespace HTMLUICompiler
{
    /// <summary>
    /// Responsible to output game runtime code, which is not pure HTML but understandable by the games runtime component
    /// </summary>
    public abstract class HTMLCompiler
    {
        public HTMLCompiler(HTMLParser parser)  
        {
            m_parser = parser;
        }

        public abstract void Compile();

        protected HTMLParser m_parser;
    }

    public class UICompiler : HTMLCompiler
    {
        public UICompiler(HTMLParser parser) : base(parser) { }

        public override void Compile()
        {
            
        }
    }

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
            m_compiler = new UICompiler(m_parser);
        }

        private void CompileUIFile(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Start Compiling");
            m_parser.CompileHTMLFile(InputFileTextBox.Text);
            m_compiler.Compile();
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
        private HTMLCompiler m_compiler;
    }
}
