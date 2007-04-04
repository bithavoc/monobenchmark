COMPILE_SYMBOL = DEBUG
RUN_ARGS= -a:../libs/Console.exe -o:../libs/summary_output.xml
all: MonoBenchmark-Console.exe

.PHONY: Core Framework

Framework:
	cd ../Framework && $(MAKE)

Core:
	cd ../Core && $(MAKE)

Libraries: Core Framework

MonoBenchmark-Console.exe: Libraries
	gmcs /target:exe /define:$(COMPILE_SYMBOL) /out:../libs/Console.exe /r:../libs/MonoBenchmark.Framework.dll /r:../libs/MonoBenchmark.Core.dll *.cs

clean:
	rm -f ../libs/Console.exe

run: all
	mono ../libs/Console.exe $(RUN_ARGS)
