// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <UIKit/UIKit.h>
#import <MapKit/MapKit.h>
#import <Foundation/Foundation.h>
#import <CoreGraphics/CoreGraphics.h>


@interface RawGPSViewController : UIViewController {
	UILabel *_LatLabel;
	UILabel *_LongLabel;
	UILabel *_SpeedLabel;
	UILabel *_RecLatLabel;
	UILabel *_RecLongLabel;
}

@property (nonatomic, retain) IBOutlet UILabel *LatLabel;

@property (nonatomic, retain) IBOutlet UILabel *LongLabel;

@property (nonatomic, retain) IBOutlet UILabel *SpeedLabel;

@property (nonatomic, retain) IBOutlet UILabel *RecLatLabel;

@property (nonatomic, retain) IBOutlet UILabel *RecLongLabel;

- (IBAction)recLoc:(id)sender;
@property (retain, nonatomic) IBOutlet UILabel *DistLabel;

@end
