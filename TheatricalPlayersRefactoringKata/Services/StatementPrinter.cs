using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using TheatricalPlayersRefactoringKata.Domain;

namespace TheatricalPlayersRefactoringKata.Services;

public class StatementPrinter
{
    public string Print(Invoice invoice, Dictionary<string, Play> plays)
    {
        var totalAmount = 0m;
        var volumeCredits = 0;
        StringBuilder result = new StringBuilder(string.Format("Statement for {0}\n", invoice.Customer));
        CultureInfo cultureInfo = new CultureInfo("en-US");

        foreach(var perf in invoice.Performances) 
        {
            var play = plays[perf.PlayId];
            var thisAmount = CalculateAmount(play, perf.Audience);
            volumeCredits += CalculateVolumeCredits(play, perf.Audience);

            // print line for this order
            result.Append(String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, thisAmount, perf.Audience));
            totalAmount = totalAmount + thisAmount;
        }
        result.Append(String.Format(cultureInfo, "Amount owed is {0:C}\n", totalAmount));
        result.Append(String.Format("You earned {0} credits\n", volumeCredits));
        return result.ToString();
    }

    private decimal CalculateAmount(Play play, int audience){
        
        var lines = play.Lines;
        if(lines < 1000) lines = 1000;
        if(lines > 4000) lines = 4000;
        //Base value
        var thisAmount = (decimal)lines / 10;

        switch (play.Type)
        {
            case "tragedy":
                if (audience > 30)
                {
                    thisAmount += (10 * (audience - 30));
                }
                break;
            case "comedy":
                if (audience > 20)
                {
                    thisAmount += 100 + (5 * (audience - 20));
                }
                thisAmount += 3 * audience;
                break;
            case "history":
                // Call the CalculateAmount function again with the current play's data, using the pricing logic for tragedy and comedy, summing the values to form the final price
                var tragedyAmount = CalculateAmount(new Play(play.Name, play.Lines, "tragedy"), audience);
                var comedyAmount = CalculateAmount(new Play(play.Name, play.Lines, "comedy"), audience);
                thisAmount = tragedyAmount + comedyAmount;
                break;
            default:
                throw new Exception("unknown type: " + play.Type);
        }

        return thisAmount;
    }

    private int CalculateVolumeCredits(Play play, int audience){
        var credits = Math.Max(audience - 30, 0);
        switch (play.Type){
            case "comedy":
                credits += (int)Math.Floor((decimal)audience/5);
                break;
            case "tragedy":
                break;
            case "history":
                break;
            default:
                throw new Exception("Unknow play type: " + play.Type);
        }

        return credits;
    }

    public XDocument PrintXml(Invoice invoice, Dictionary<string, Play> plays)
    {
        var totalAmount = 0m;
        var volumeCredits = 0;
        var statementElement = new XElement("Statement",
        new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
        new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema")
        );

            statementElement.Add(new XElement("Customer",invoice.Customer));
            var itemsElement = new XElement("Items");

            foreach (var perf in invoice.Performances)
            {
                var play = plays[perf.PlayId];
                var thisAmount = CalculateAmount(play, perf.Audience);
                var thisCredits = CalculateVolumeCredits(play, perf.Audience);

                var itemElement = new XElement("Item");
                itemElement.Add(new XElement("AmountOwed", thisAmount));
                itemElement.Add(new XElement("EarnedCredits", thisCredits));
                itemElement.Add(new XElement("Seats", perf.Audience));

                itemsElement.Add(itemElement);
                totalAmount += thisAmount;
                volumeCredits += thisCredits;
            }
            
            statementElement.Add(itemsElement);
            statementElement.Add(new XElement("AmountOwed", totalAmount));
            statementElement.Add(new XElement("EarnedCredits", volumeCredits));

            return new XDocument(new XDeclaration("1.0", "utf-8", "yes"), statementElement);
    }

}
