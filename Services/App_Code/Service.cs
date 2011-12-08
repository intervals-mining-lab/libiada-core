using System.Web.Services;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Calculate;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.GenerateMarkovChains;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.PhantomChains;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Segmentation;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : WebService
{

    [WebMethod]
    public string CreateAlphabetInput(RequestFiles request)
    {
       ServiceManager SM = ServiceManager.Create();
       return SM.NewCalculation(request,WebServiceType.Alphabet);
    }

    [WebMethod]
    public AnswerObjects CreateAlphabetOutput(string hash)
    {
        ServiceManager SM = ServiceManager.Create();
        return (AnswerObjects)SM.Check(hash, WebServiceType.Alphabet);
    }

    [WebMethod]
    public string CalculateInput(RequestFiles request)
    {
        ServiceManager SM = ServiceManager.Create();
        return SM.NewCalculation(request, WebServiceType.Calculate);
    }

    [WebMethod]
    public AnswerChain CalculateOutput(string hash)
    {
        ServiceManager SM = ServiceManager.Create();
        return (AnswerChain)SM.Check(hash, WebServiceType.Calculate);
    }

    [WebMethod]
    public string MarkovChainInput(RequestMarkovChain request)
    {
        ServiceManager SM = ServiceManager.Create();
        return SM.NewCalculation(request, WebServiceType.MarkovChain);
    }

    [WebMethod]
    public AnswerMarkovChain MarkovChainOutput(string hash)
    {
        ServiceManager SM = ServiceManager.Create();
        return (AnswerMarkovChain)SM.Check(hash, WebServiceType.MarkovChain);
    }

    [WebMethod]
    public string KRABInput(RequestClusterization request)
    {
        ServiceManager SM = ServiceManager.Create();
        return SM.NewCalculation(request, WebServiceType.Clusterization);
    }

    [WebMethod]
    public AnswerClusterization KRABOutput(string hash)
    {
        ServiceManager SM = ServiceManager.Create();
        return (AnswerClusterization)SM.Check(hash, WebServiceType.Clusterization);
    }

    [WebMethod]
    public string PhantomChainsInput(RequestPhantomChains request)
    {
        ServiceManager SM = ServiceManager.Create();
        return SM.NewCalculation(request, WebServiceType.PhantomChain);
    }

    [WebMethod]
    public AnswerPhantomChains PhantomChainsOutput(string hash)
    {
        ServiceManager SM = ServiceManager.Create();
        return (AnswerPhantomChains)SM.Check(hash, WebServiceType.PhantomChain);
    }

    [WebMethod]
    public string SegmentationInput(RequestSegmentation request)
    {
        ServiceManager SM = ServiceManager.Create();
        return SM.NewCalculation(request, WebServiceType.Segmentation);
    }

    [WebMethod]
    public AnswerSegmentation SegmentationOutput(string hash)
    {
        ServiceManager SM = ServiceManager.Create();
        return (AnswerSegmentation)SM.Check(hash, WebServiceType.Segmentation);
    }


}