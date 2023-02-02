using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.CameraProjection;
using static Raylib_cs.Color;
using static Raylib_cs.GamepadAxis;
using static Raylib_cs.GamepadButton;

const int screenWidth = 800;
const int screenHeight = 450;

bool flipColors = false;
bool calibMode = true;
double lastTime = 0.0;

// CAM:<2.6676736, -1.1054237, 13.211298> + TARG:<3.380985, -0.49967182, 0> + UP<0.110801294, 0.9197867, 0>


SetConfigFlags(ConfigFlags.FLAG_WINDOW_UNDECORATED);
InitWindow(screenWidth, screenHeight, "raylib");
SetWindowMonitor(2);
Camera3D camera = new()
{
    position = new(10.0f, 10.0f, 10.0f), // Camera3D position
    target = Vector3.Zero,               // Camera3D looking at point
    up = new(0.0f, 1.0f, 0.0f),          // Camera3D up vector (rotation towards target)
    fovy = 45.0f,                        // Camera3D field-of-view Y
    projection = CAMERA_PERSPECTIVE      // Camera3D mode type
};
Vector3 cubePosition = Vector3.Zero;

while (!WindowShouldClose()) // Detect window close button or ESC key
{
    UpdateCamera(ref camera);
    BeginDrawing();
    ClearBackground(RAYWHITE);
    BeginMode3D(camera);
    
    if (IsGamepadAvailable(0))
    {
        if (IsGamepadButtonPressed(0, GAMEPAD_BUTTON_MIDDLE_LEFT))
        {
            camera.position = new(2.6676736f, -1.1054237f, 13.211298f);
            camera.target = new(3.380985f, -0.49967182f, 0f);
            camera.up = new(0.110801294f, 0.9197867f, 0f);
        }
        if (IsGamepadButtonPressed(0, GAMEPAD_BUTTON_MIDDLE_RIGHT))
            calibMode = !calibMode;

        if (calibMode)
        {
            DrawGrid(10, 1.0f);
            DrawCube(cubePosition, 8, 8, 0.1f, RED);
            camera.position.X += GetGamepadAxisMovement(0, GAMEPAD_AXIS_LEFT_X) / 500f;
            camera.position.Y += GetGamepadAxisMovement(0, GAMEPAD_AXIS_LEFT_Y) / 500f;
            camera.target.X -= GetGamepadAxisMovement(0, GAMEPAD_AXIS_RIGHT_X) / 500f;
            camera.target.Y += GetGamepadAxisMovement(0, GAMEPAD_AXIS_RIGHT_Y) / 500f;
            if (IsGamepadButtonDown(0, GAMEPAD_BUTTON_LEFT_TRIGGER_2))
                camera.position.Z -= 0.001f;
            if (IsGamepadButtonDown(0, GAMEPAD_BUTTON_RIGHT_TRIGGER_2))
                camera.position.Z += 0.001f;
            if (IsGamepadButtonDown(0, GAMEPAD_BUTTON_LEFT_FACE_UP))
                camera.up.Y += 0.0001f;
            if (IsGamepadButtonDown(0, GAMEPAD_BUTTON_LEFT_FACE_DOWN))
                camera.up.Y -= 0.0001f;
            if (IsGamepadButtonDown(0, GAMEPAD_BUTTON_LEFT_FACE_LEFT))
                camera.up.X -= 0.0001f;
            if (IsGamepadButtonDown(0, GAMEPAD_BUTTON_LEFT_FACE_RIGHT))
                camera.up.X += 0.0001f;
        }
        else
        {
            double thisTime = GetTime();
            Console.WriteLine(thisTime - lastTime);
            if (thisTime - lastTime > 2)
            {
                flipColors = !flipColors;
                lastTime = thisTime;
            }

            Color a = flipColors ? GREEN : RED;
            Color b = flipColors ? BLUE : YELLOW;
            for (float i = -3.5f; i < 3.5f; i += 2f)
            {
                for (float j = -3.5f; j < 3.5f; j += 2f)
                    DrawCube(new Vector3(i, j, 0f), 1, 1, 0.1f, a);
                for (float j = -2.5f; j < 4.5f; j += 2f)
                    DrawCube(new Vector3(i + 1f, j, 0f), 1, 1, 0.1f, a);
                for (float j = -2.5f; j < 4.5f; j += 2f)
                    DrawCube(new Vector3(i, j, 0f), 1, 1, 0.1f, b);
                for (float j = -3.5f; j < 3.5f; j += 2f)
                    DrawCube(new Vector3(i + 1f, j, 0f), 1, 1, 0.1f, b);
            }
        }
    }

    EndMode3D();
    EndDrawing();

    Console.WriteLine($"CAM:{camera.position} + TARG:{camera.target} + UP{camera.up}");
}
CloseWindow();