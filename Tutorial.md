# Introduction #

This is a introducion to MonoBenchmark Perfomance Tool.

You will learn to:
  * Build test code using C#
  * Compile test assemblies
  * Run test assemblies and analyze results.

# Steps #

First we must create a _C#_ source file with the code to test, you can use any text editor like _vi\_m or_gedit_but I will use_vim_Editor._

## Step 1: Create the source code ##

Create a source file called "perfomance.cs"

The following instruction will create a file perfomance.cs in vim editor.

`vim perfomance.cs`

Copy and Paste the following code:

```

using System;
using MonoBenchmark.Framework;

[TimeFixture]
public class PerfomanceFixture1
{
        [TimeCount]
        public void Test1()
        {
                System.Threading.Thread.Sleep(200); //Delay 200 Milliseconds
        }
        [TimeCount(Workers=2)]
        public void WorkloadTest()
        {
                System.Threading.Thread.Sleep(20);
        }
}

```

_**Note**: If you are using vim editor, remember save and close the file typing `:x`_

## Step 2: Compile the test ##

> Now we compile the test using the following instruction:

`gmcs -pkg:monobenchmark-framework /out:perfomance.dll /target:library perfomance.cs`

You will see a file called "perfomance.dll" in the current directory.

_**Note:** use "-pkg:monobenchmark-framework" if you want to reference  MonoBenchmark.Framework.dll assembly, use "-pkg:monobenchmark-core" if you want to reference MonoBenchmark.Core.dll assembly._

## Step 3: Run the test ##

Execute the following instruction in order to run the test:

monobenchmark -a:perfomance.dll -o:perfomance-Results.xml

You will see a file called "perfomance-Results.xml" in the current directory.

The content is like the following:

```

<?xml version="1.0" encoding="utf-8"?>
<testSummary assemblyName="perfomance, Version=0.0.0.0, Culture=neutral">
  <fixtures>
    <fixture name="PerfomanceFixture1">
      <test name="WorkloadTest">
        <time id="0" startTime="04/06/2007 17:51:34" endTime="04/06/2007 17:51:34" time="00:00:00.0471280" />
        <time id="1" startTime="04/06/2007 17:51:34" endTime="04/06/2007 17:51:34" time="00:00:00.0452540" />
      </test>
      <test name="Test1">
        <time id="0" startTime="04/06/2007 17:51:34" endTime="04/06/2007 17:51:34" time="00:00:00.2043350" />
      </test>
    </fixture>
  </fixtures>
</testSummary>

```