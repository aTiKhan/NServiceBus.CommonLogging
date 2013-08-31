NServiceBus.CommonLogging
=========================

Add support for sending [NServiceBus](http://nservicebus.com/) logging message through [CommonLogging](https://github.com/net-commons/common-logging)

## Nuget

https://nuget.org/packages/NServiceBus.CommonLogging/
    
    PM> Install-Package NServiceBus.CommonLogging

## Usage 

	//Configure Common.Logging
    LogManager.Adapter = new MemoryAdapter();

	//Connect Common.Logging to NServiceBus
    CommonLoggingConfigurator.Configure();

	//Start using NServiceBus     
    var configure = Configure
        .With().DefaultBuilder();

## Icon

<a href="http://thenounproject.com/noun/bus/#icon-No16553" target="_blank">Bus</a> designed by <a href="http://thenounproject.com/rafa.goicoechea" target="_blank">Rafa Goicoechea</a> from The Noun Project