module YOLOInference

open Microsoft.ML.OnnxRuntime
open Emgu.CV
open Emgu.CV.Structure
open System

let loadModel (modelPath: string) =
    try
        Some(new InferenceSession(modelPath))
    with
    | ex ->
        printfn "Failed to load model: %s" ex.Message
        None

let preprocessImage (image: Image<Bgr, byte>) =
    // Convert image to tensor or the appropriate format for your model
    let resizedImage = image.Resize(224, 224, Emgu.CV.CvEnum.Inter.Linear) // Adjust as necessary
    let inputTensor = // Implement this conversion based on your needs
        let data = resizedImage.Data
        let tensor = Array3D.init 224 224 3 (fun x y z -> float32 data.[x, y, z])
        tensor
    inputTensor

let runInference (session: InferenceSession) (tensor: Tensors.Tensor<float32>) =
    // Convert tensor to NamedOnnxValue collection
    let namedOnnxValues = [ NamedOnnxValue.CreateFromTensor("input", tensor) ]
    // Run the model with proper error handling
    try
        Some(session.Run(namedOnnxValues))
    with
    | ex ->
        printfn "Error during inference: %s" ex.Message
        None
