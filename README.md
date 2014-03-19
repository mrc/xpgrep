# xpgrep

```sh
% mono xpgrep.exe '//turtle[@name="Leonardo"]/weapon' sample.xml
-- file:///Users/mrc/shed/fsharp/xpgrep/sample.xml:4:8
 <weapon>Katana</weapon>

% mono xpgrep.exe '//turtle[@name="Leonardo"]/weapon/text()' sample.xml
-- file:///Users/mrc/shed/fsharp/xpgrep/sample.xml:4:23
 Katana
```
