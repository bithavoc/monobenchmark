OUTDIR = Debug

all: MonoBenchmark.dll

MonoBenchmark.dll:
	gmcs /target:library /out:bin/$(OUTDIR)/MonoBenchmark.dll -r:System.Xml.dll *.cs

