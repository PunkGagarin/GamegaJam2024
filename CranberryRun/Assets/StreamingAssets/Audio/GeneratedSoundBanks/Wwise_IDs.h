/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID AMBIENCE = 85412153U;
        static const AkUniqueID LOST = 221232711U;
        static const AkUniqueID PLAY_MAINMUSICSWITCH = 3684206702U;
        static const AkUniqueID ROLLING = 4227290872U;
        static const AkUniqueID ROLLING_STOP = 2225439287U;
        static const AkUniqueID WON = 1080430619U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace GAMESTATUS
        {
            static const AkUniqueID GROUP = 1045871717U;

            namespace STATE
            {
                static const AkUniqueID INGAME = 984691642U;
                static const AkUniqueID INMENU = 3374585465U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace GAMESTATUS

        namespace MUSICSTATE
        {
            static const AkUniqueID GROUP = 1021618141U;

            namespace STATE
            {
                static const AkUniqueID FAST = 2965380179U;
                static const AkUniqueID MEDIUM = 2849147824U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID SLOW = 787604482U;
            } // namespace STATE
        } // namespace MUSICSTATE

        namespace PLAYERSTATE
        {
            static const AkUniqueID GROUP = 3285234865U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID PLAYERALIVE = 2557321869U;
                static const AkUniqueID PLAYERDEAD = 2356585300U;
            } // namespace STATE
        } // namespace PLAYERSTATE

    } // namespace STATES

    namespace SWITCHES
    {
        namespace PLAYER_SPEED
        {
            static const AkUniqueID GROUP = 1062779386U;

            namespace SWITCH
            {
                static const AkUniqueID FAST = 2965380179U;
                static const AkUniqueID MEDIUM = 2849147824U;
                static const AkUniqueID SLOW = 787604482U;
            } // namespace SWITCH
        } // namespace PLAYER_SPEED

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID RTPC_PLAYERSPEED = 2653406601U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID GAME = 702482391U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID GAMEPLAY = 89505537U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID STATUSEFFECT = 3306938624U;
        static const AkUniqueID UI = 1551306167U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
