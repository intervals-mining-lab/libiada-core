using System.Collections;
using System.Xml.Serialization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Answers;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices.db_interface
{
    public class AnswerChains : Answer
    {
        [XmlArrayItem(typeof (int))] public ArrayList chains = new ArrayList();
    }
}