using System;
using System.Collections.Generic;
using System.Xml;
using MonoGame.Extended.Serialization.Xml;

namespace FishGameV2;

public class ParserJeux
{
    private XmlDocument doc;
    private XmlNode root;
    private XmlNamespaceManager nsmgr;

    public ParserJeux(String filenamme)
    {
        doc = new XmlDocument();
        doc.Load(filenamme);
        root = doc.DocumentElement;
        nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace(root.Prefix, root.NamespaceURI);
    }


   static public int ParserPositionJoueurX(String filename)
    {
        //Parse le fichier
        XmlReader reader = XmlReader.Create(filename);
        int x = 0;

        while (reader.Read())
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                        if (reader.Name == "Joueur")
                        { 
                            x = reader.GetAttributeInt("x");
                           //int y = reader.GetAttributeInt("y");
                           //position.Add(x);
                           //position.Add(y);
                        }
                        break;
            }
        }
        return x;
    }
}