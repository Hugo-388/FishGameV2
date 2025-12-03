using System;
using System.Collections.Generic;
using System.Xml;

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


   static public HashSet<String> ParserInfosJoueur(String filename)
    {
        //Parse le fichier
        XmlReader reader = XmlReader.Create(filename);
        HashSet<String> position = new HashSet<String>();
        

        while (reader.Read())
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    if (reader.Name == "General")
                    {
                        
                        if (reader.Name == "Joueur")
                        {
                            reader.MoveToFirstAttribute();
                            position.Add(reader.Value);
                            Console.WriteLine("Joueur: " + reader.Value);
                        }
                    }
                    
                    break;
            }
        }

        return position;
    }
}