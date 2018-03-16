namespace Task_04
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            XmlParser xmlParser = new XmlParser(args[0]);
            Element element = xmlParser.ParseElement();
            element.Sort();
            element.Print("", false);
        } 
    }
}
