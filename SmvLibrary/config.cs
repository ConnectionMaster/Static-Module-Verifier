﻿using System.Collections.Generic;
using System.Xml.Serialization;
using System;

// 
// This source code was auto-generated by xsd, Version=4.0.30319.1 and then modified
// 

namespace SmvLibrary
{
    [XmlRootAttribute(Namespace = "")]
    [Serializable]
    public class SMVConfig
    {

        [XmlArrayItemAttribute("SetVar", typeof(SetVar))]
        public SetVar[] Variables { get; set; }

        [XmlArrayItemAttribute("Action", typeof(SMVAction))]
        public SMVAction[] Build { get; set; }

        [XmlArrayItemAttribute("Action", typeof(SMVAction))]
        public SMVAction[] Analysis { get; set; }
    }

    [XmlRootAttribute("Action", Namespace = "")]
    [Serializable]
    public class SMVAction
    {
        public SMVAction()
        {
            this.breakOnError = true;
            this.name = string.Empty;
            this.executeOn = "local";
            this.variables = null;
        }
        public SMVAction(SMVCommand[] commands, string name)
        {
            this.breakOnError = true;
            this.name = name;
            this.Command = commands;
            this.executeOn = "local";
            this.variables = null;
        }

        public SMVAction(SMVAction orig, string analysisProperty)
        {
            this.breakOnError = orig.breakOnError;
            this.name = orig.name;
            this.Command = orig.Command;
            this.Path = orig.Path;
            this.Env = orig.Env;
            this.CopyArtifact = orig.CopyArtifact;
            this.executeOn = orig.executeOn;
            this.nextAction = orig.nextAction;
            this.variables = orig.variables;
            this.analysisProperty = analysisProperty;
        }

        public PathType Path { get; set; }

        [XmlElementAttribute("Env")]
        public SMVEnvVar[] Env { get; set; }

        [XmlElementAttribute("CopyArtifact")]
        public CopyArtifactType[] CopyArtifact { get; set; }

        [XmlElementAttribute("Command")]
        public SMVCommand[] Command { get; set; }

        [XmlAttributeAttribute()]
        public string name { get; set; }

        [XmlAttributeAttribute()]
        public bool breakOnError { get; set; }

        [XmlAttributeAttribute()]
        public string executeOn { get; set; }

        [XmlAttributeAttribute()]
        public string nextAction { get; set; }

        [XmlIgnoreAttribute]
        public SMVActionResult result { get; set; }

        [XmlIgnoreAttribute]
        public string analysisProperty { get; set; }

        [XmlIgnoreAttribute]
        public IDictionary<string, string> variables { get; set; }
    

        public string GetFullName() 
        {
            return (string.IsNullOrEmpty(analysisProperty)) ? name : name + " - " + analysisProperty;
        }
    }

    [XmlRootAttribute("SetVar", Namespace = "")]
    [Serializable]
    public class SetVar
    {
        [XmlAttributeAttribute()]
        public string key { get; set; }

        [XmlAttributeAttribute()]
        public string value { get; set; }
    }
    
    [XmlRootAttribute("Path", Namespace = "")]
    [Serializable]
    public class PathType
    {

        [XmlAttributeAttribute()]
        public string value { get; set; }
    }

    [XmlRootAttribute("Env", Namespace = "")]
    [Serializable]
    public class SMVEnvVar
    {
        [XmlAttributeAttribute()]
        public string key { get; set; }

        [XmlAttributeAttribute()]
        public string value { get; set; }
    }

    [XmlRootAttribute("CopyArtifact", Namespace = "")]
    [Serializable]
    public class CopyArtifactType
    {

        [XmlAttributeAttribute()]
        public string name { get; set; }

        [XmlAttributeAttribute()]
        public string type { get; set; }

        [XmlAttributeAttribute()]
        public entityAttrType entity { get; set; }

        [XmlAttributeAttribute()]
        public string to { get; set; }
    }

    public enum entityAttrType
    {
        Module,
        CompilationUnit,
        FunctionUnit,
    }

    [XmlRootAttribute("Command", Namespace = "")]
    [Serializable]
    public class SMVCommand
    {
        [XmlAttributeAttribute()]
        public string value { get; set; }

        [XmlAttributeAttribute()]
        public string arguments { get; set; }
    }

    [Serializable]
    public class SMVActionResult
    {
        public SMVActionResult(string name, string output, bool isSuccessful, bool breakExecution)
        {
            this.name = name;
            this.output = output;
            this.isSuccessful = isSuccessful;
            this.breakExecution = breakExecution;
        }

        public string name { get; private set; }
        public string output { get; set; }
        public bool isSuccessful { get; private set; }
        public bool breakExecution { get; private set; }
    }
}