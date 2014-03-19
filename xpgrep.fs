open System
open System.Xml
open System.Xml.XPath

let xgrep (xpath:string) (filenames:seq<string>) =
  let results =
    filenames
    |> Seq.map (fun filename -> XPathDocument(filename))
    |> Seq.map (fun doc -> doc.CreateNavigator())
    |> Seq.map (fun nav -> nav.Select(xpath) |> Seq.cast)
    |> Seq.concat

  for (r:XPathNavigator) in results do
    printfn "%s" r.BaseURI
    printfn " %s" r.OuterXml

  ()

[<EntryPoint>]
let main args =
  let xpath = args.[0]
  let filenames = Seq.skip 1 args

  xgrep xpath filenames
  0


