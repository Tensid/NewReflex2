using System;

namespace VisaRService.Contracts
{
    public class ConfigItem
    {
        public string Name;
        public string FbServiceUrl;
        public string FbServiceDatabase;
        public string FbServiceUser;
        public string FbServicePassword;
        public AgsConfig AgsConfig;
        public EcosConfig EcosConfig;
        public ByggrConfig ByggrConfig;
    }

    public class AgsConfig
    {
        public string Username;
        public string Password;
        public string Instance;
        public string Department;
        public string SearchWay;
        public string CasePattern;
        public string DocumentPattern;
        public string DateField;
        public bool EstateNameSearch;
        public string ServiceUrl;
    }

    public class ByggrConfig
    {
        public string[] DocumentTypes;
        public string[] OccurenceTypes;
        public string[] PersonRoles;
        public string[] Tabs;
        public bool WorkingMaterial;
        public bool HideCasesWithSecretOccurences;
        public string HideDocumentsWithCommentMatching;
        public bool OnlyCasesWithoutMainDecision;
        public bool OnlyActiveCases;
        public DateTime? MinCaseStartDate;
        public string ConnectionString;
        public string ServiceUrl;
    }

    public class EcosConfig
    {
        public string ServiceUrl;
        public string Username;
        public string Password;
    }
}
