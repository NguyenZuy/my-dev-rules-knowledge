# SOLID 

- Is an arconym for the first five OOP principles.
- Stand for:
    - 👉 S - Single Responsibility
    👉 O - Open Slose
    👉 L - Liskov Subsititution 
    👉 I - Interface Segregation
    👉 D - Dependency Inversion

### S - Single Responsibility

- A class should have one and only one reason to change, meaning that a class should have only one job.
Example:
Not: 
``` 
Player.cs
public class Player : Monobehaviour
{
    public void Move() {};
    
    public void UpdateScore() {};

    public void UpdateAnimation() {};
}
```
👉 Should
```
