#include <math.h>

/**
 * reconstruction error
 */
_inline waveform rec(waveform x, waveform y) {
  return x - y;
}

/**
 * variance of digitized signal
 */
_inline double var(waveform u) {
  double sum = 0;
  for (size_t i = 0; i < u.length; i++) {
    sum += u[i] * u[i];
  return sum / u.length;
}

/**
 * Ratio of signal variance to reconstruction error variance
 * (in decibels).
 */
_inline double SNR(waveform x, waveform y) {
  return 10 * log10 (var(x) / var(rec(x, y)));
}
