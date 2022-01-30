using System;
using System.Collections.Generic;
using VDS.RDF;
using VDS.RDF.Writing;
using VDS.RDF.Parsing;
using VDS.RDF.Ontology;


public class HelloWorld
{
    public static void Main(String[] args)
    {
        Console.WriteLine(Environment.CurrentDirectory);

        var g = new Graph();

        // Add namespaces (RDF and RDFS are already declared)
        g.NamespaceMap.AddNamespace("owl", UriFactory.Create("http://www.w3.org/2002/07/owl#"));

        // Create nodes (this could be done inline in the Assert code if you prefer

        var a = g.CreateUriNode("rdf:type");
        var owlClass = g.CreateUriNode("owl:Class");
        var owlObjectProperty = g.CreateUriNode("owl:ObjectProperty");
        var rdfsLabel = g.CreateUriNode("rdfs:label");
        var rdfsDomain = g.CreateUriNode("rdfs:domain");
        var rdfsRange = g.CreateUriNode("rdfs:range");
        
            
        // Lion
        var lion = g.CreateUriNode(UriFactory.Create("http://my.taxonomies.com/myModel/Lion"));
        g.Assert(lion, a, owlClass);
        g.Assert(lion, rdfsLabel, g.CreateLiteralNode("Lion", "en"));

        // Animal
        var animals = g.CreateUriNode(UriFactory.Create("http://my.taxonomies.com/myModel/Animals"));
        g.Assert(animals, a, owlClass);
        g.Assert(animals, rdfsLabel, g.CreateLiteralNode("Animals", "en"));

        // Relation
        var isPartOf = g.CreateUriNode("rdf:type");
        g.Assert(isPartOf, a, owlObjectProperty);
        g.Assert(isPartOf, rdfsLabel, g.CreateLiteralNode("isPartOf", "en"));

        g.Assert(isPartOf, rdfsDomain, lion);
        g.Assert(isPartOf, rdfsRange, animals);

      // g.Assert(lion, isPartOf, animals);


      //  var Test = g.CreateBlankNode();
      //  var String = g.CreateVariableNode("String");
         
      //  g.Assert(String, String, String);
       // g.Assert(Test, Test, Test);






        //var BHoM = g.CreateUriNode(UriFactory.Create("https://bhom.xyz/"));
        // g.Assert(BHoM, a, owlClass);
        //g.Assert(BHoM, rdfsLabel, g.CreateLiteralNode("BHoM", "en"));


        // var BHoM_Architecture_oM_Elements_Room = g.CreateUriNode(UriFactory.Create("https://github.com/BHoM/BHoM/blob/main/Architecture_oM/Elements/Room.cs"));
        // g.Assert(BHoM_Architecture_oM_Elements_Room, a, owlClass);
        // g.Assert(BHoM_Architecture_oM_Elements_Room, rdfsLabel, g.CreateLiteralNode("BHoM_Architecture_oM_Elements_Room", "en"));


        //   g.Assert(BHoM_Architecture_oM_Elements_Room, isPartOf, BHoM);








        // var o = new OntologyGraph();
        //  var lion1 = o.CreateOntologyClass(UriFactory.Create("http://my.taxonomies.com/myModel/Lion"));
        // lion1.AddType(UriFactory.Create(OntologyHelper.OwlClass));
        /// lion1.AddLabel("Lion", "en");
        //  var animals1 = o.CreateOntologyClass(UriFactory.Create("http://my.taxonomies.com/myModel/Animals"));
        //   lion1.AddSuperClass(animals1);
        // var isPart = o.CreateOntologyClass(UriFactory.Create("http://my.taxonomies.com/myModel"));
        // isPart.AddType(UriFactory.Create(OntologyHelper.OwlObjectProperty));


        RdfXmlWriter rdfxmlwriter = new RdfXmlWriter();
        rdfxmlwriter.Save(g, "LionAnimal.rdf");
        //rdfxmlwriter.Save(o, "ontol.rdf");
    }
}

