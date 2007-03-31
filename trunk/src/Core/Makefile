all: MonoBenchmark.Core.dll

Framework:
	cd ../Framework && $(MAKE)

MonoBenchmark.Core.dll: Framework
	gmcs /target:library /out:"../libs/MonoBenchmark.Core.dll" /r:System.Xml.dll /r:"../libs/MonoBenchmark.Framework.dll" *.cs Analysis/*

