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

        return new XDocument(new XDeclaration("1.0", "utf-8", "yes"), statementElement).ToString();
    }
}