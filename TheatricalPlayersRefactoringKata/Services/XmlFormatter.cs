using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TheatricalPlayersRefactoringKata.Services;

public class XmlFormatter : IFormatter
{
    public string Format(StatementData statementData)
    {
        var statementElement = new XElement("Statement",
            new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
            new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"));

        statementElement.Add(new XElement("Customer", statementData.Customer));
        var itemsElement = new XElement("Items");

        foreach (var performance in statementData.Performances)
        {
            var itemElement = new XElement("Item");
            itemElement.Add(new XElement("AmountOwed", performance.Amount));
            itemElement.Add(new XElement("EarnedCredits",performance.EarnedCredits));
            itemElement.Add(new XElement("Seats", performance.Audience));
            itemsElement.Add(itemElement);
        }

        statementElement.Add(itemsElement);
        statementElement.Add(new XElement("AmountOwed", statementData.TotalAmount));
        statementElement.Add(new XElement("EarnedCredits", statementData.VolumeCredits));
        XDeclaration declaration = new XDeclaration("1.0","utf-8","yes");
        XDocument xmlDocument = new XDocument(declaration,statementElement);
        SaveXmlArchive(xmlDocument,statementData);

        return xmlDocument.ToString();
    }

    public async Task SaveXmlArchive(XDocument xml, StatementData statementData){
        string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"Downloads");
        string nameArchive = statementData.Customer;
        string filePath = Path.Combine(directory,$"{nameArchive}.xml");
        
        try
        {
            using (var fileStream = new FileStream(filePath,FileMode.Create,FileAccess.Write,FileShare.None,4096,true)){
                await xml.SaveAsync(fileStream,SaveOptions.None,default);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error ocurred while saving the file: {ex.Message}");
        }
    }
}