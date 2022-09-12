# TestEngie


le projet est une Api rest serveless  azurefonction qui contient deux endpoints
 - RegularExpressionApi
 - GetHistorySearchApi
 
  - pour le déployement sur azure il faut un plan App Service
  
 pour tester l'application en local 
 - ouvrir le projet avec vs
 - démarrer l'application (F5)
 - tester avec postman
 
## Reqûete 1 : 
 POST : 
 http://localhost:7071/api/RegularExpressionApi 
 
 paramètre dans body json : 
 {
    "MatchingType":"3", ==> enumération pour choisir le type de matching (0 :  basic ,1 :  sans flags,2 : avec flags ,3  : avec l'option de sibstitution)
     "RegEx":"(\\+33|0)?(\\d)?(\\d\\d)?(\\d\\d)?(\\d\\d)?(\\d\\d)",
     "Text":"+33755221102 phone number 2   +33755221109",
     "Flags" :["i"],
     "TextSubstitution":"****"
}

Retour de la reqûete : 
{
    "isMatch": true,
    "nombreMatching": 2,
    "textAfterSubstitution": "**** abassi  ****",
    "matchingInformations": [
        {
            "idMatching": "Full Match",
            "titleMtching": "Group 0",
            "valueMatching": "+33755221102",
            "matchingPositionLength": "0-12",
            "groupes": [
                {
                    "idGroup": "Group 1",
                    "titleGroup": "Group 1",
                    "valueGroup": "+33",
                    "matchingPositionLength": "0-3"
                },
                {
                    "idGroup": "Group 2",
                    "titleGroup": "Group 2",
                    "valueGroup": "7",
                    "matchingPositionLength": "3-1"
                },
                {
                    "idGroup": "Group 3",
                    "titleGroup": "Group 3",
                    "valueGroup": "55",
                    "matchingPositionLength": "4-2"
                },
                {
                    "idGroup": "Group 4",
                    "titleGroup": "Group 4",
                    "valueGroup": "22",
                    "matchingPositionLength": "6-2"
                },
                {
                    "idGroup": "Group 5",
                    "titleGroup": "Group 5",
                    "valueGroup": "11",
                    "matchingPositionLength": "8-2"
                },
                {
                    "idGroup": "Group 6",
                    "titleGroup": "Group 6",
                    "valueGroup": "02",
                    "matchingPositionLength": "10-2"
                },
                {
                    "idGroup": "Group 7",
                    "titleGroup": "Group ",
                    "valueGroup": "",
                    "matchingPositionLength": "0-0"
                }
            ]
        },
        {
            "idMatching": "Full Match",
            "titleMtching": "Group 0",
            "valueMatching": "+33755221102",
            "matchingPositionLength": "21-12",
            "groupes": [
                {
                    "idGroup": "Group 1",
                    "titleGroup": "Group 1",
                    "valueGroup": "+33",
                    "matchingPositionLength": "21-3"
                },
                {
                    "idGroup": "Group 2",
                    "titleGroup": "Group 2",
                    "valueGroup": "7",
                    "matchingPositionLength": "24-1"
                },
                {
                    "idGroup": "Group 3",
                    "titleGroup": "Group 3",
                    "valueGroup": "55",
                    "matchingPositionLength": "25-2"
                },
                {
                    "idGroup": "Group 4",
                    "titleGroup": "Group 4",
                    "valueGroup": "22",
                    "matchingPositionLength": "27-2"
                },
                {
                    "idGroup": "Group 5",
                    "titleGroup": "Group 5",
                    "valueGroup": "11",
                    "matchingPositionLength": "29-2"
                },
                {
                    "idGroup": "Group 6",
                    "titleGroup": "Group 6",
                    "valueGroup": "02",
                    "matchingPositionLength": "31-2"
                },
                {
                    "idGroup": "Group 7",
                    "titleGroup": "Group ",
                    "valueGroup": "",
                    "matchingPositionLength": "0-0"
                }
            ]
        }
    ]
}

## Reqûete 2: 
Get : 
 http://localhost:7071/api/GetHistorySearchApi
Retour : la liste de recherches précédentes
##Conception 
![testengie (1)](https://user-images.githubusercontent.com/16887977/189690378-27ce660a-783d-4c75-9475-9681a4b47a0f.jpg)
