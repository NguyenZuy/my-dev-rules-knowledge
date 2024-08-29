# SOLID Principles in Object-Oriented Programming

- SOLID is an acronym for the first five OOP principles designed to make software designs more understandable, flexible, and maintainable.
- **Stand for:**
    - 👉 [S - Single Responsibility](#s---single-responsibility)
    - 👉 [O - Open Close](#o---open-close)
    - 👉 [L - Liskov Substitution](#l---liskov-substitution)
    - 👉 [I - Interface Segregation](#i---interface-segregation)
    - 👉 [D - Dependency Inversion](#d---dependency-inversion)
    
### S - Single Responsibility

- A class should have one and only one reason to change, meaning that a class should have only one job.
- Example:
``` C#
// Before

// Player.cs
public class Player : Monobehaviour
{
    public void Move() {};
    
    public void UpdateScore() {};

    public void UpdateAnimation() {};
}
```

``` C#
// After

// PlayerMovement.cs
public class PlayerMovement : Monobehaviour
{
    public void Move() {};
}

// PlayerScore.cs
public class PlayerScore : Monobehaviour
{
    public void UpdateScore() {};
}

// PlayerAnimation.cs
public class PlayerAnimation : Monobehaviour
{
    public void UpdateAnimation() {};
}
```

### O - Open Close

- Objects or entities should be open for extension but closed for modification.
- Example: 
``` C#
// Before

// Rectangle.cs
public class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
}

// AreaCalculator.cs
public class AreaCalculator
{
    public double CalculateArea(Rectangle rectangle)
    {
        return rectangle.Width * rectangle.Height;
    }
}
```

``` C#
// After

// Shape.cs
public abstract class Shape
{
    public abstract double CalculateArea();
}

// Rectangle.cs
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

// Circle.cs
public class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

// AreaCalculator.cs
public class AreaCalculator
{
    public double CalculateArea(Shape shape)
    {
        return shape.CalculateArea();
    }
}
```

### L - Liskov Substitution

- Every subclass or derived class should be substitutable for their base or parent class.
- Example:
``` C#
// Before

// Bird.cs
public class Bird
{
    public virtual void Fly() { }
}

// Penguin.cs
public class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotImplementedException("Penguins can't fly!");
    }
}

// BirdWatcher.cs
public class BirdWatcher
{
    public void WatchBird(Bird bird)
    {
        bird.Fly();
    }
}

```

``` C#
// After

// Bird.cs
public abstract class Bird
{
    public abstract void Move();
}

// Sparrow.cs
public class Sparrow : Bird
{
    public override void Move()
    {
        Fly();
    }

    private void Fly() 
    {
        // Implementation for flying
    }
}

// Penguin.cs
public class Penguin : Bird
{
    public override void Move()
    {
        Swim();
    }

    private void Swim() 
    {
        // Implementation for swimming
    }
}

// BirdWatcher.cs
public class BirdWatcher
{
    public void WatchBird(Bird bird)
    {
        bird.Move();
    }
}

```

### I - Interface Segregation

- A client should never be forced to implement an interface that it doesn’t use, or clients shouldn’t be forced to depend on methods they do not use.
- Example:
``` C#
// Before

// IPlayer.cs
public interface IPlayer
{
    void Move();
    void Attack();
    void Defend();
    void Heal();
}

// Warrior.cs
public class Warrior : IPlayer
{
    public void Move() { }
    public void Attack() { }
    public void Defend() { }
    public void Heal()
    {
        throw new NotImplementedException();
    }
}

// Healer.cs
public class Healer : IPlayer
{
    public void Move() { }
    public void Attack()
    {
        throw new NotImplementedException();
    }
    public void Defend()
    {
        throw new NotImplementedException();
    }
    public void Heal() { }
}

```

``` C#
// After

public interface IMovable
{
    void Move();
}

public interface IAttackable
{
    void Attack();
}

public interface IDefendable
{
    void Defend();
}

public interface IHealable
{
    void Heal();
}

public class Warrior : IMovable, IAttackable, IDefendable
{
    public void Move() { }
    public void Attack() { }
    public void Defend() { }
}

public class Healer : IMovable, IHealable
{
    public void Move() { }
    public void Heal() { }
}

```

### D - Dependency Inversion

- Entities must depend on abstractions, not on concretions. It states that the high-level module must not depend on the low-level module, but they should depend on abstractions.
- Example:
``` C#
// Before

// Low-level class
// EmailService.cs
public class EmailService
{
    public void SendEmail(string message)
    {
        // Implementation for sending an email
    }
}

// High-level class
// Notification.cs
public class Notification
{
    private EmailService _emailService;

    public Notification()
    {
        _emailService = new EmailService();
    }

    public void Send(string message)
    {
        _emailService.SendEmail(message);
    }
}

```

``` C#
// After

// Abstraction
// IMessageService.cs
public interface IMessageService
{
    void SendMessage(string message);
}

// Low-level class
// EmailService.cs
public class EmailService : IMessageService
{
    public void SendMessage(string message)
    {
        // Implementation for sending an email
    }
}

// Another low-level class
// SmsService.cs
public class SmsService : IMessageService
{
    public void SendMessage(string message)
    {
        // Implementation for sending an SMS
    }
}

// High-level class
// Notification.cs
public class Notification
{
    private readonly IMessageService _messageService;

    public Notification(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Send(string message)
    {
        _messageService.SendMessage(message);
    }
}

```