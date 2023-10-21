using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CarControllerTest
{
    private GameObject carGameObject;
    private CarController carController;

    [SetUp]
    public void SetUp()
    {
        carGameObject = new GameObject("DodgeCharger");
        carController = carGameObject.AddComponent<CarController>();
    }

    [TearDown]
    public void TearDown()
    {
        // Destroy may not be called from edit mode!
        Object.DestroyImmediate(carGameObject);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void CarControllerTest_Move_ShouldChangePosition()
    {
        // guardamos posicion inicial
        Vector3 initialPosition = carGameObject.transform.position;

        // llamamos el metodo Move
        carController.Move();

        // comprobamos que la posicion ha cambiado
        Assert.AreNotEqual(initialPosition, carGameObject.transform.position);
    }

    [Test]
    public void CarControllerTest_ChangeDirection_ShouldChangeRotation()
    {
        // Guardar rotacion incial
        Quaternion initialRotation = carGameObject.transform.rotation;

        // llama el metodo ChangeDIrection
        carController.ChangeDirection();

        // comprobamos que la rotacion haya cambiado
        Assert.AreNotEqual(initialRotation, carGameObject.transform.rotation);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    //[UnityTest]
    //public IEnumerator CarControllerTestWithEnumeratorPasses()
    //{
    //    // Use the Assert class to test conditions.
    //    // Use yield to skip a frame.
    //    yield return null;
    //}
}
