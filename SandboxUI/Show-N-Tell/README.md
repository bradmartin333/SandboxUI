# Everyone should know how to write code

Code can look like this (*Assembly*)

``` assembly
org  0x100
mov  dx, msg
mov  ah, 9
int  0x21
mov  ah, 0x4c
int  0x21
msg  db 'Hello, World!', 0x0d, 0x0a, '$'
```

or this (*C#*)

```cs
namespace HelloWorld
{
    class Hello {         
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
        }
    }
}
```

or this (*Python*)

```python
print("Hello, World!")
```

or even this (*Scratch*)

![scratch](https://www.i-programmer.info/images/stories/Core/OtherLang/Scratch/helloworld3.gif)

and it **really doesn't matter where you start**.

# This progam

`Show-N-Tell` is a program made with C#.

The purpose of the program is order a list of topics from most exciting to least exciting.

`strings` (like "Hello World") are shown to the room and each one is ranked based on how much noise the participants make.

It is a nice ice-breaker and gets people engaged (And off mute for video meetings). 

# Why?

I believe everyone can be excited about programming if shown an application that interests them.

For me, I was hooked by printing shapes to the console like this

```
 ___            ___
/   \          /   \
\_   \        /  __/
 _\   \      /  /__
 \___  \____/   __/
     \_       _/
       | @ @  \_
       |
     _/     /\
    /o)  (o/\ \_
    \_____/ /
      \____/
```

and then it was making games

![raylib](https://miro.medium.com/max/1400/1*4tmGx3shRuI7oD34TCYAtg.gif)

and now it is making tools

![3dprinter](https://3dprintingindustry.com/wp-content/uploads/2018/01/lulzbot.gif)

# [Just jump in!](https://youtu.be/-F6THkPkF2I)

