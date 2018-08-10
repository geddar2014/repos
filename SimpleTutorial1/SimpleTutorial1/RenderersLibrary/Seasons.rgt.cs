namespace RenderersLibrary
{
    using System;
    using System.Xml;

    public partial class Seasons
    {
        private void RenderProjectItem()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(base.ProjectItem.GetCurrentContentAsString());

            foreach (XmlAttribute attr in xmlDocument.SelectNodes("/Seasons/Season/@Name"))
            {
                this.RenderItem(attr.Value);
            }
        }
    }
}