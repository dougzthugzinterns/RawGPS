// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import "RawGPSViewController.h"

@implementation RawGPSViewController

@synthesize LatLabel = _LatLabel;
@synthesize LongLabel = _LongLabel;
@synthesize SpeedLabel = _SpeedLabel;
@synthesize RecLatLabel = _RecLatLabel;
@synthesize RecLongLabel = _RecLongLabel;
@synthesize DistLabel = _DistLabel;

- (IBAction)recLoc:(id)sender {
}

- (void)dealloc {
    [_MagHeadLabel release];
    [_TrueHeadLabel release];
    [super dealloc];
}
@end
