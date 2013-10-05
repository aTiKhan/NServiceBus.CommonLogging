NServiceBus.CommonLogging
=========================

Add support for sending [NServiceBus](http://nservicebus.com/) logging message through [CommonLogging](https://github.com/net-commons/common-logging)

## Nuget


There are two nuget packages

### The [binary version](http://nuget.org/packages/NServiceBus.CommonLogging/)

This uses the standard approach to constructing a nuget package. It contains a dll which will be added as a reference to your project. You then deploy the binary with your project.

    PM> Install-Package NServiceBus.CommonLogging

### The [code only version](http://nuget.org/packages/NServiceBus.CommonLogging-CodeOnly/)

This is a "code only" package that leverages the [Content Convention](http://docs.nuget.org/docs/creating-packages/creating-and-publishing-a-package#From_a_convention_based_working_directory) of Nuget to inject code files into your project. Note that this is only compatible with C# projects. 

The benefits of this approach are ease of debugging and less files to deploy

    PM> Install-Package NServiceBus.CommonLogging-CodeOnly

## Usage 

	//Configure Common.Logging
    LogManager.Adapter = new MemoryAdapter();

	//Connect Common.Logging to NServiceBus
    CommonLoggingConfigurator.Configure();

	//Start using NServiceBus     
    var configure = Configure
        .With().DefaultBuilder();

## Is a reference necessary

You may be thinking that having an assembly reference to achieve this functionality is undesirable. If this is the case you should avoid the reference by taking the following steps.
 
* Copy [LoggingFactory](https://github.com/SimonCropp/NServiceBus.CommonLogging/blob/master/NServiceBus.CommonLogging/LoggerFactory.cs) into your project 
* Copy [Logger](https://github.com/SimonCropp/NServiceBus.CommonLogging/blob/master/NServiceBus.CommonLogging/Logger.cs) into your project
* Call this code when you application starts `NServiceBus.LogManager.LoggerFactory = new LoggerFactory();`

## Icon

<a href="http://thenounproject.com/noun/bus/#icon-No16553" target="_blank">Bus</a> designed by <a href="http://thenounproject.com/rafa.goicoechea" target="_blank">Rafa Goicoechea</a> from The Noun Project