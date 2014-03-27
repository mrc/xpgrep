open System
open System.Xml
open System.Xml.XPath

module Xpgrep =

  type XgrepResult = {filename:string; nav:XPathNavigator}

  let xgrep (xpath:string) (filenames:seq<string>) : seq<XgrepResult> =
    seq { for filename in filenames do
          for nav in XPathDocument(filename)
            .CreateNavigator()
            .Select(xpath) |> Seq.cast do
            yield {filename=filename; nav=nav} }

  let showResult (result:XgrepResult) =
    let (info:IXmlLineInfo) = (result.nav :> Object) :?> IXmlLineInfo
    printfn "<!-- %s:%d (%A) -->" result.filename info.LineNumber result.nav.NodeType
    printfn " %s" result.nav.OuterXml

  [<EntryPoint>]
  let main args =
    let xpath = args.[0]
    let filenames = Seq.skip 1 args
    xgrep xpath filenames
    |> Seq.iter showResult
    0
