
# Neo.Extensions.DependencyInjection

NuGet package: https://www.nuget.org/packages/Neo2.Extensions.DependencyInjection/

## What is Configuration?

Configuration drives how your application behaves. Your application may be a web app, console app, WPF / Windows Form app but it won’t be very useful if its behaviour can’t be tailored to users’ preference.

For web / console app running in a server environment, behaviour driven by configuration means you can run the same codebase but allow users to decide how they want to use the service. For example, a microservice that sends out reports via email may need to have SMTP settings configured. A Windows app such as an advanced video player tailored for HTPC enthusiasts will need to be able to have its video processing pipeline fully configurable.

## Dependency Injection (DI)

Dependency Injection (DI) is a widely used technique to ease the pain of manually creating objects that has dependencies on other objects, hence the name dependency injection. It is also very opinionated about the way it works and how it should be used. This is great from a standardisation standpoint — it reduces the cognitive load when others read your code. However, as soon as you need something that isn’t supported out of the box, you do not have the luxury of relying on the opinions too.
.NET Core DI

In the case of the .Net Core DI, it stops short of allowing you a convenient and opionated way of binding types based on config (e.g. from appsettings.json). Veterans will use a factory pattern without second thoughts while others will fumble and get it wrong but that’s beyond the scope of this article.

The problem arises when you have a lot of configs. Using the video player example, you would have your basic settings (the DirectX version, GPU, number of render ahead frames etc.), as well as the settings afforded by each video processor that can be inserted into the video processing pipeline. That itself is also configurable. At this point, you can have hundreds of factories. Or, you can be smart about it and create something opinionated and reusable to reduce the cognitive complexities.

![Example of Video Processors that are Individually Configurable](https://imgur.com/download/IvZkd1Y)

Imagine you could do something like the following instead.

```C#
services.AddConfig<VideoProcessorPipelineOptions>();
services.AddConfig<CompositePipelineOptions>();

services.AddConfig<LaplacianPyramidCnnUpscalerOptions>();
services.AddConfig<NNedi3UpscalerOptions>();
services.AddConfig<EwaUpscalerOptions>();
services.AddConfig<EwaDownscalerOptions>();
services.AddConfig<SSimDownscalerOptions>();
services.AddConfig<DebandOptions>();

services.AddSingletonFromFactory<IVideoProcessorPipeline>(
	factory => factory
		.AddService<NullPipeline>() // see null object pattern
		.AddService<CompositePipeline>() // see composite pattern
		.WithOption<VideoProcessorPipelineOptions>(o => o.Pipeline));
		
services.AddSingletonFromFactory<IEnumerable<IVideoProcessor>>(
	factory => factory
		.AddService<LaplacianPyramidCnnUpscaler>()
		.AddService<NNedi3Upscaler>()
		.AddService<EwaUpscaler>()
		.AddService<EwaDownscaler>()
		.AddService<SSimDownscaler>()
		.AddService<Deband>()
		// ...
		.WithOption<CompositePipelineOptions>(o => o.ProcessorNames));

public class VideoProcessorPipelineOptions
{
	public string Pipeline { get; set; } = nameof(NullPipeline);
}

public class CompositePipelineOptions
{
	public string[] ProcessorNames { get; set; } = Array.Empty<string>();
}

public class CompositePipeline : IVideoProcessorPipeline
{
	public CompositePipeline(IEnumerable<IVideoProcessor> videoProcessors)
	{
		// ...
	}
	
	public IVideoFrame Process(IVideoFrame input)
	{
		// ...
	}
}
```

Your settings would come from the normal places supported by .NET core — environment vars, appsettings.json etc.

The good news is we don’t have to imagine any of the above. It's readily available via NuGet package.

## Plugin Architecture

What if you want the video processors to be plugins instead? In this case, you should dynamically load the assemblies like you normally would and call `AddConfig()` / `factory.AddService()` programmatically for each of the plugins to register them.

## Limitations

For apps running in a server environment, this is generally not a problem, but `ReloadOnChange` from `IOptions` is not supported. Instead, it is recommended that you create a separate and isolated service provider for objects that need to be changed at run-time (e.g. when user changes config via GUI). This way, you can get that service provider to give you a new set of objects and easily replace the ones you are currently using. In the video processing pipeline example above, `Process()` is a method of `IVideoProcessorPipeline`. Swapping the instance out under it would automatically cause video processing to switch to the new pipeline when `Process()` is called for the next video frame.
