using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Interfaces;

namespace Segmentation.Classes.Model
{
    public class MainOutputData
    {
        private ComplexChain chain;
    private FrequencyDictionary alphabet;
    private Order order;
    private Dictionary<String, String> parameters = new Dictionary<String, String>();

    public String getChainName(){
        return chain.GetName();
    }
    public Chain getChain() {
        return chain;
    }

    public void setChain(ComplexChain chain) {
        this.chain = chain;
    }

    public FrequencyDictionary getFrequencyDictionary() {
        return alphabet;
    }

    public void setFrequencyDictionary(FrequencyDictionary alphabet) {
        this.alphabet = alphabet;
    }

    public Order getOrder() {
        return order;
    }

    public void setOrder(Order order) {
        this.order = order;
    }

    public Dictionary<String, String> getParameters() {
        return parameters;
    }

    /**
     * Allows you add an additional information about research
     *
     * @param what parameter name
     * @param value string value
     */
    public void addInfo(IIdentifiable what, IIdentifiable value){
        parameters.Add(what.GetName(), value.GetName());
    }
    /**
     * Allows you add an additional information about research
     *
     * @param what parameter name
     * @param value digit value
     */
    public void addInfo(IIdentifiable what, IDefinable value){
        parameters.Add(what.GetName(), value.getValue().ToString());
    }

    /**
     * Allows you add an additional information about research
     *
     * @param what parameter name
     * @param value digit calculated value
     */
    public void addInfo(IIdentifiable what, Double value){
        parameters.Add(what.GetName(), value.ToString());
    } 
    }
}