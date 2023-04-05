# Starter from https://matplotlib.org/stable/gallery/mplot3d/scatter3d.html

import matplotlib.pyplot as plt
import numpy as np
import requests

# Prompt user for a random string
random_string = input("Enter a random string: ")

# Convert all non integers in the string to a random integer between 0 and 9
for i in range(len(random_string)):
    if not random_string[i].isdigit():
        random_string = random_string[:i] + \
            str(np.random.randint(0, 10)) + random_string[i+1:]

# Convert the string to an integer
random_int = int(random_string)

# Clamp the integer between 0 and 2^32-1
random_int = random_int % 2**32

# Fixing random state for reproducibility
np.random.seed(random_int)


def randrange(n, vmin, vmax):
    """
    Helper function to make an array of random numbers having shape (n, )
    with each number distributed Uniform(vmin, vmax).
    """
    return (vmax - vmin)*np.random.rand(n) + vmin


fig = plt.figure()
ax = fig.add_subplot(projection='3d')

n = 100

# For each set of style and range settings, plot n random points in the box
# defined by x in [23, 32], y in [0, 100], z in [zlow, zhigh].
for m, zlow, zhigh in [('o', -50, -25), ('^', -30, -5)]:
    xs = randrange(n, 23, 32)
    ys = randrange(n, 0, 100)
    zs = randrange(n, zlow, zhigh)
    ax.scatter(xs, ys, zs, marker=m)

# Generate 3 random dictionary words using a web API
api = 'https://random-word-api.herokuapp.com/word?number=3'
words = requests.get(api).json()
# Capitalize the first letter of each word
words = [word.capitalize() for word in words]

ax.set_xlabel(words[0])
ax.set_ylabel(words[1])
ax.set_zlabel(words[2])

plt.show()
