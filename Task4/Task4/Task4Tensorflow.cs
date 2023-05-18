using System;
using Tensorflow;
using Tensorflow.Keras;
using Tensorflow.Keras.Engine;
using Tensorflow.Keras.Layers;
using Tensorflow.Keras.Utils;
using static Tensorflow.Binding;
using NumSharp;
//using static Tensorflow.Python;

/// <summary>
/// Summary description for Class1
/// </summary>

		static void Main() {
			var(xTrain, yTrain), (xTest, yTest) = Tensorflow.Keras.Datasets.Mnist.load_data();

						
		}
	

