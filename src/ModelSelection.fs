// LICENSE
// This project is proprietary and all rights are reserved by the author.
// Unauthorized copying, distribution, or modification of this project is strictly prohibited.
// Unless You have written permission from the Developer or the FNBUBBLES420 ORG.

module ModelSelection

type ModelConfig = {
    Path: string
    Description: string
}

let availableModels = [
    { Path = "yolov5s.onnx"; Description = "YOLOv5 small for real-time detection" }
    { Path = "yolov5m.onnx"; Description = "YOLOv5 medium for balance" }
    { Path = "yolov5l.onnx"; Description = "YOLOv5 large for high accuracy" }
    { Path = "yolov5x.onnx"; Description = "YOLOv5 extra large for high performance" }
    { Path = "yolov8s.onnx"; Description = "YOLOv8 small for real-time detection" }
    { Path = "yolov8m.onnx"; Description = "YOLOv8 medium for balance" }
    { Path = "yolov8l.onnx"; Description = "YOLOv8 large for high accuracy" }
    { Path = "yolov8x.onnx"; Description = "YOLOv8 extra large for high performance" }
    { Path = "yolov9s.onnx"; Description = "YOLOv9 small for real-time detection" }
    { Path = "yolov9m.onnx"; Description = "YOLOv9 medium for balance" }
    { Path = "yolov9l.onnx"; Description = "YOLOv9 large for high accuracy" }
    { Path = "yolov9x.onnx"; Description = "YOLOv9 extra large for high performance" }
    { Path = "yolov10s.onnx"; Description = "YOLOv10 small for real-time detection" }
    { Path = "yolov10m.onnx"; Description = "YOLOv10 medium for balance" }
    { Path = "yolov10l.onnx"; Description = "YOLOv10 large for high accuracy" }
    { Path = "yolov10x.onnx"; Description = "YOLOv10 extra large for high performance" }
    { Path = "yolov11s.onnx"; Description = "YOLOv11 small for real-time detection" }
    { Path = "yolov11m.onnx"; Description = "YOLOv11 medium for balance" }
    { Path = "yolov11l.onnx"; Description = "YOLOv11 large for high accuracy" }
    { Path = "yolov11x.onnx"; Description = "YOLOv11 extra large for high performance" }

]

let selectModel index =
    if index < 0 || index >= availableModels.Length then
        failwith "Model index out of range"
    availableModels.[index]
