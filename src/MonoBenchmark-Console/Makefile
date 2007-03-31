all: MonoBenchmark-Console.exe

Framework:
	cd ../Framework && $(MAKE)

Core:
	cd ../Core && $(MAKE)

Libraries: Core Framework

MonoBenchmark-Console.exe: Libraries
	gmcs /target:exe /out:../libs/Console.exe /r:../libs/MonoBenchmark.Framework.dll /r:../libs/MonoBenchmark.Core.dll *.cs

clean:
	rm -f ../libs/Console.exe

run: all
	mono ../libs/Console.exe
