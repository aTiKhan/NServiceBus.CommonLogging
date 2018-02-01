NServiceBus.CommonLogging
=========================

Add support for sending [NServiceBus](http://particular.net/NServiceBus) logging message through [CommonLogging](https://github.com/net-commons/common-logging)

## Nuget

http://nuget.org/packages/NServiceBus.CommonLogging/

    PM> Install-Package NServiceBus.CommonLogging

## Usage 

Perform the following before configuring NServiceBus

```
LogManager.Adapter = new ConsoleOutLoggerFactoryAdapter();

NServiceBus.Logging.LogManager.Use<CommonLoggingFactory>();
```