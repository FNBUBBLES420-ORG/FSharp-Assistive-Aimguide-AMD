module ScreenCapture

open System
open System.Drawing
open SharpDX
open SharpDX.Direct3D11
open SharpDX.DXGI
open SharpDX.Direct3D
open System.Threading.Tasks

let factory = new Factory1()
let adapter = factory.GetAdapter1(0)  // Primary GPU
let device, swapChain = Device.CreateWithSwapChain(
    adapter, 
    DeviceCreationFlags.None, 
    [| FeatureLevel.Level_11_0 |], 
    new SwapChainDescription(
        BufferCount = 1,
        ModeDescription = new ModeDescription(1920, 1080, Rational(60, 1), Format.R8G8B8A8_UNorm),
        Usage = Usage.RenderTargetOutput,
        OutputHandle = IntPtr.Zero,
        SampleDescription = new SampleDescription(1, 0),
        SwapEffect = SwapEffect.Discard,
        Flags = SwapChainFlags.None
    )
)
let output = adapter.GetOutput(0)
let outputDuplication = output.QueryInterface<Output1>().DuplicateOutput(device)

let captureScreenAsync () =
    task {
        let frameInfo = new OutputDuplicateFrameInformation()
        use texture = new Texture2D(device, new Texture2DDescription(
            Width = 1920,
            Height = 1080,
            MipLevels = 1,
            ArraySize = 1,
            Format = Format.B8G8R8A8_UNorm,
            Usage = ResourceUsage.Staging,
            BindFlags = BindFlags.None,
            CpuAccessFlags = CpuAccessFlags.Read,
            OptionFlags = ResourceOptionFlags.None
        ))

        let! _ = Task.Run(fun () ->
            let result, frameInfo, texture = outputDuplication.TryAcquireNextFrame(500)
            if result.Failure then failwith "Failed to acquire next frame"
        )

        return texture
    }
