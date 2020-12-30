# Xamarin AccessibilityService
This is a minimal AccessibilityService made in Xamarin, that is supposed create an overlay that is shown over the screen.

Following Google's Accessibility Service codelab: https://codelabs.developers.google.com/codelabs/developing-android-a11y-service/#0


Steps to reproduce:
- Clone repro project
- Run project
- Go to Settings > Accessibility and enable "Input Service"

Expected Behaviour: 
- Overlay is displayed, as shown in codelab

Actual Behaviour:
- WindowManagerBadTokenException
