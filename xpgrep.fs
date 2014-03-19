open System
open System.Xml
open System.Xml.XPath

let xgrep (xpath:string) (filenames:seq<string>) =
  let (results:seq<XPathNavigator>) =
    filenames
    |> Seq.map (fun filename -> XPathDocument(filename))
    |> Seq.map (fun doc -> doc.CreateNavigator())
    |> Seq.map (fun nav -> nav.Select(xpath) |> Seq.cast)
    |> Seq.concat

  for r in results do
    let (info:IXmlLineInfo) = (r :> Object) :?> IXmlLineInfo
    printfn "-- %s:%d:%d" r.BaseURI info.LineNumber info.LinePosition
    printfn " %s" r.OuterXml

  ()

[<EntryPoint>]
let main args =
  let xpath = args.[0]
  let filenames = Seq.skip 1 args

  xgrep xpath filenames
  0


