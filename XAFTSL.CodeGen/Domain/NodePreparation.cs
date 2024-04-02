//-----------------------------------------------------------------------
// <copyright file="NodePreparation.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 07:41:38
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;
using System.Xml.Linq;
using XAFTSL.CodeGen.Interfaces;

namespace XAFTSL.CodeGen.Domain
{
    public class NodePreparation
    {
        private bool myFileIsXAFMLFile = true;

        private readonly IEnumerable<XElement>? myNodeElements;

        public NodePreparation(string fileName)
        {
            try
            {
                myNodeElements = XElement.Load(fileName).Elements(Predefinitions.XAFMLLocalizationNode);
            } catch
            {
                myFileIsXAFMLFile = false;
            }
        }


        private List<INodeData> GetListOfNodeData(IEnumerable<XElement> xmlNodeData)
        {
            List<INodeData> locListOfNodeData = new List<INodeData>();
            foreach(XElement locXMLNodeData in xmlNodeData)
            {
                Context.XAFMLNodeData locNodeData = new Context.XAFMLNodeData();
                if(locXMLNodeData.Name.ToString() == Predefinitions.XAFMLLocalizationItem)
                {
                    if(locXMLNodeData.FirstAttribute?.Name.ToString() == Predefinitions.XAFMLLocalizationItemAttribute)
                    {
                        locNodeData.PropertyName = locXMLNodeData.FirstAttribute.Value;
                        locNodeData.IsAllowedToExport = true;
                    }
                }

                locListOfNodeData.Add(locNodeData);
            }
            return locListOfNodeData;
        }

        private INode GetNode(XElement xmlNode)
        {
            Context.XAFMLNode locNode = new Context.XAFMLNode();
            if(xmlNode != null)
            {
                var locXmlNodeGroupAttribute = xmlNode.Attribute(Predefinitions.XAFMLLocalizationGroupAttribute);

                if(locXmlNodeGroupAttribute != null)
                {
                    locNode.NodeName = locXmlNodeGroupAttribute.Value.ToString();

                    if(xmlNode.Elements(Predefinitions.XAFMLLocalizationGroup).Count() > 0)
                    {
                        foreach(XElement locNodeElement in xmlNode.Elements(Predefinitions.XAFMLLocalizationGroup))
                        {
                            var locChildNode = GetNode(locNodeElement);
                            locNode.ChildNodes.Add(locChildNode);
                            if(locNodeElement.Elements(Predefinitions.XAFMLLocalizationItem).Count() > 0)
                            {
                                locChildNode.NodeData = GetListOfNodeData(
                                    locNodeElement.Elements(Predefinitions.XAFMLLocalizationItem));
                            }
                        }
                    }
                }
            }
            return locNode;
        }

        public List<INode> GetNodes()
        {
            List<INode> locNodes = new List<INode>();
            if(myNodeElements != null)
            {
                foreach(XElement locNodeElement in myNodeElements.Elements(Predefinitions.XAFMLLocalizationGroup))
                {
                    locNodes.Add(GetNode(locNodeElement));
                }
            }

            return locNodes;
        }

        public bool FileIsXAFMLFile => myFileIsXAFMLFile;
    }
}
