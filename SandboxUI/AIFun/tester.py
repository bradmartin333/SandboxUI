import cv2
import numpy as np
from matplotlib import pyplot as plt

img_path = r'C:\Users\bmartin\source\repos\SandboxUI\SandboxUI\AIFun\image.bmp'

# Load the image
img = cv2.imread(img_path, 0)

# Compute the 2D FFT of the image
f = np.fft.fft2(img)
fshift = np.fft.fftshift(f)
magnitude_spectrum = 20*np.log(np.abs(fshift))

# Filter the magnitude spectrum
middle_x = magnitude_spectrum.shape[0] / 2
middle_y = magnitude_spectrum.shape[1] / 2
for i in range(magnitude_spectrum.shape[0]):
    for j in range(magnitude_spectrum.shape[1]):
        if (i > middle_x - 50 and i < middle_x + 50) or (j > middle_y - 50 and j < middle_y + 50):
            fshift[i, j] = 0

# Magnitude spectrum after filtering
magnitude_spectrum_filtered = 20*np.log(np.abs(fshift))

# Reconstruct the image from the magnitude spectrum
f_ishift = np.fft.ifftshift(fshift)
img_back = np.fft.ifft2(f_ishift)
img_back = np.abs(img_back)

# Convert the reconstructed image to CV_8UC1
img_blobs = np.uint8(img_back)
ret, img_blobs = cv2.threshold(img_blobs, 0, 255, cv2.THRESH_BINARY+cv2.THRESH_OTSU)

# Display the original image, the magnitude spectrum, 
# the filtered magnitude spectrum, the reconstructed image
# and the contours
plt.subplot(231), plt.imshow(img, cmap='gray')
plt.title('Input Image'), plt.xticks([]), plt.yticks([])
plt.subplot(232), plt.imshow(magnitude_spectrum, cmap='gray')
plt.title('Magnitude Spectrum'), plt.xticks([]), plt.yticks([])
plt.subplot(233), plt.imshow(magnitude_spectrum_filtered, cmap='gray')
plt.title('Filtered Magnitude Spectrum'), plt.xticks([]), plt.yticks([])
plt.subplot(234), plt.imshow(img_back, cmap='gray')
plt.title('Reconstructed Image'), plt.xticks([]), plt.yticks([])
plt.subplot(235), plt.imshow(img_blobs, cmap='gray')
plt.title('Contours'), plt.xticks([]), plt.yticks([])
plt.show()
