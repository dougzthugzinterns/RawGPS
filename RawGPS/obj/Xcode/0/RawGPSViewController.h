// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface RawGPSViewController : UIViewController {
	UILabel *_LatLabel;
	UILabel *_LongLabel;
	UILabel *_SpeedLabel;
	UILabel *_RecLatLabel;
	UILabel *_RecLongLabel;
	UILabel *_DistLabel;
	UILabel *_MagHeadLabel;
	UILabel *_TrueHeadLabel;
}

@property (nonatomic, retain) IBOutlet UILabel *LatLabel;

@property (nonatomic, retain) IBOutlet UILabel *LongLabel;

@property (nonatomic, retain) IBOutlet UILabel *SpeedLabel;

@property (nonatomic, retain) IBOutlet UILabel *RecLatLabel;

@property (nonatomic, retain) IBOutlet UILabel *RecLongLabel;

@property (nonatomic, retain) IBOutlet UILabel *DistLabel;

@property (nonatomic, retain) IBOutlet UILabel *MagHeadLabel;

@property (nonatomic, retain) IBOutlet UILabel *TrueHeadLabel;

- (IBAction)recLoc:(id)sender;
@property (retain, nonatomic) IBOutlet UILabel *pointsLabel;

@end
