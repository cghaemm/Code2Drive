using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Animal
{
    public void poo() 
    {
        Debug.Log("Animal has pooped");
    }

    public void eat() {
        Debug.Log("Animal has eaten");
    }
}

public class Dog : Animal
{
    public void bark() {
        Debug.Log("BARK!");
    }

    public void rollOver() {
        Debug.Log("Dog has rollen over!");
    }
}

Dog myDog = new Dog(); // creates a dog
myDog.poo(); // prints out "Animal has pooped"
myDog.eat(); // prints out "Animal has eaten"
myDog.bark(); // prints out "BARK!"

Animal myAnimal = new Animal();
myAnimal.bark(); // ERROR
myAnimal.rollOver(); // ERROR
myDog.rollOver(); // prints out "Dog has rollen over!"
*/

public class RoadLine : IMoveable
{
    private float deltaBuffer = 120f;

    public override void moveToStart()
    {
        gameObject.transform.Translate(new Vector3(-deltaBuffer, 0, 0), Space.World);
    }
}
