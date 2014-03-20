xpgrep.exe : xpgrep.fs
	fsharpc --nologo xpgrep.fs

test : xpgrep.exe
	mono xpgrep.exe '//turtle[@name="Leonardo"]/weapon' sample.xml
